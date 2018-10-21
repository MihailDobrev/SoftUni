namespace SIS.Framework.Routes
{
    using SIS.Framework.Controllers;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Response.Contracts;
    using SIS.WebServer.Api.Contracts;
    using SIS.Framework.ActionResults.Contracts;
    using SIS.WebServer.Results;
    using SIS.HTTP.Enums;
    using SIS.Framework.Attributes.Methods.Base;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using System.Reflection;
    using SIS.HTTP.Extensions;
    using System.ComponentModel.DataAnnotations;

    public class ControllerRouter : IHttpHandler
    {
        private const string UnsupportedActionMessage = "This type of result is not supported";
        private const string get = "get";

        public IHttpResponse Handle(IHttpRequest request)
        {
            var controllerName = string.Empty;
            var actionName = string.Empty;
            var requestMethod = request.RequestMethod.ToString();

            if (request.Url == MvcContext.DirectorySeparator)
            {
                controllerName = "Home";
                actionName = "Index";
            }
            else
            {
                string[] requestUrlSplit = request.Url.Split(MvcContext.DirectorySeparator, StringSplitOptions.RemoveEmptyEntries);

                if (requestUrlSplit.Length == 2 || requestUrlSplit.Length == 3)
                {
                    requestMethod = request.RequestMethod.ToString();
                    controllerName = requestUrlSplit[0].Capitalize();
                    actionName = requestUrlSplit[1].Capitalize();
                }

            }

            var controller = this.GetController(controllerName, request);

            var action = this.GetAction(requestMethod, controller, actionName);
            object[] actionParameters = this.MapActionParameters(action, request, controller);
            IActionResult actionResult = this.InvokeAction(controller, action, actionParameters);

            return this.PrepareResponse(actionResult);
        }

        private IActionResult InvokeAction(Controller controller, MethodInfo action, object[] actionParameters)
        {
            return (IActionResult)action.Invoke(controller, actionParameters);
        }

        private object[] MapActionParameters(
             MethodInfo action,
             IHttpRequest request,
             Controller controller)
        {         
            ParameterInfo[] actionParameteres = action.GetParameters();
            object[] mappedActionParameters = new object[actionParameteres.Length];

            for (int i = 0; i < actionParameteres.Length; i++)
            {
                var actionParameter = actionParameteres[i];

                if (actionParameter.ParameterType.IsPrimitive ||
                    actionParameter.ParameterType == typeof(string))
                {
                    var mappedActionParameter = new object();

                    mappedActionParameter = this.ProcessPrimitiveParameter(actionParameter, request);
                    if (mappedActionParameter == null)
                    {
                        break;
                    }
                }
                else
                {
                    object bindingModel = this.ProcessesBindingModelParameter(actionParameter, request);
                    controller.ModelState.IsValid = this.IsValid(bindingModel, actionParameter.ParameterType);
                    mappedActionParameters[i] = bindingModel;
                }
            }

            return mappedActionParameters;
        }

        private bool? IsValid(object bindingModel, Type bindingModelType)
        {
            var properties = bindingModelType.GetProperties();

            foreach (var property in properties)
            {
                var propertyValidationAttributes = property
                    .GetCustomAttributes()
                    .Where(ca => ca is ValidationAttribute)
                    .Cast<ValidationAttribute>()
                    .ToList();

                foreach (var validationAttribute in propertyValidationAttributes)
                {
                    var propertyValue = property.GetValue(bindingModel);

                    if (!validationAttribute.IsValid(propertyValue))
                    {
                        return false;
                    }
                }
            }

            return true;
        }


        private object ProcessPrimitiveParameter(
         ParameterInfo actionParameter,
         IHttpRequest request)
        {
            var value = this.GetParameterFromRequestData(request, actionParameter.Name);

            if (value == null)
            {
                return value;
            }

            return Convert.ChangeType(value, actionParameter.ParameterType);
        }

        private object ProcessesBindingModelParameter(
            ParameterInfo actionParameter,
            IHttpRequest request)
        {
            Type bindingModelType = actionParameter.ParameterType;

            var bindingModelInstance = Activator.CreateInstance(bindingModelType);

            var bindingModelProperties = bindingModelType.GetProperties();

            foreach (var bindingModelProperty in bindingModelProperties)
            {
                try
                {
                    var value = this.GetParameterFromRequestData(
                        request,
                        bindingModelProperty.Name.ToLower());

                    bindingModelProperty.SetValue(
                        bindingModelInstance,
                        Convert.ChangeType(value, bindingModelProperty.PropertyType));
                }
                catch (Exception)
                {
                    Console.WriteLine($"The property {bindingModelProperty.Name} could not be mapped");
                }
            }

            return Convert.ChangeType(bindingModelInstance, bindingModelType);
        }

        private object GetParameterFromRequestData(
           IHttpRequest request,
           string actionParameterName)
        {
            if (request.QuerryData.ContainsKey(actionParameterName))
            {
                return request.QuerryData[actionParameterName];
            }

            if (request.FormData.ContainsKey(actionParameterName))
            {
                return request.FormData[actionParameterName];
            }

            return null;
        }

        private IHttpResponse PrepareResponse(IActionResult actionResult)
        {

            string invocationResult = actionResult.Invoke();

            if (actionResult is IViewable)
            {
                return new HtmlResult(invocationResult, HttpResponseStatusCode.OK);
            }

            if (actionResult is IRedirectable)
            {
                return new RedirectResult(invocationResult);
            }

            throw new InvalidOperationException(UnsupportedActionMessage);
        }

        private Controller GetController(string controllerName, IHttpRequest request)
        {
            if (string.IsNullOrEmpty(controllerName))
            {
                return null;
            }

            string controllerTypeName = string.Format(
                "{0}.{1}.{2}{3}, {0}",
                MvcContext.Get.AssemblyName,
                MvcContext.Get.ControllersFolder,
                controllerName,
                MvcContext.Get.ControllerSuffix
                );
            Type controllerType = Type.GetType(controllerTypeName);

            Controller controller = null;

            if (controllerType != null)
            {
                controller = (Controller)Activator.CreateInstance(controllerType);
            }

            if (controller != null)
            {

                controller.Request = request;
            }

            return controller;
        }

        private MethodInfo GetAction(string requestMethod, Controller controller, string actionName)
        {
            var actions = this
                .GetSuitableMethods(controller, actionName)
                .ToList();

            if (!actions.Any())
            {
                return null;
            }

            foreach (var action in actions)
            {
                var httpMethodAttributes = action
                    .GetCustomAttributes()
                    .Where(ca => ca is HttpMethodAttribute)
                    .Cast<HttpMethodAttribute>()
                    .ToList();

                if (!httpMethodAttributes.Any() &&
                    requestMethod.ToLower() == get)
                {
                    return action;
                }

                foreach (var httpMethodAttribute in httpMethodAttributes)
                {
                    if (httpMethodAttribute.IsValid(requestMethod))
                    {
                        return action;
                    }
                }
            }

            return null;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods(Controller controller, string actionName)
        {
            if (controller == null)
            {
                return new MethodInfo[0];
            }

            return controller
                .GetType()
                .GetMethods()
                .Where(mi => mi.Name.ToLower() == actionName.ToLower());
        }

    }
}
