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


    public class ControllerRouter : IHttpHandler
    {
        public IHttpResponse Handle(IHttpRequest request)
        {
            var controllerName = string.Empty;
            var actionName = string.Empty;
            var requestMethod = request.RequestMethod.ToString();

            if (request.Url == "/")
            {
                controllerName = "Home";
                actionName = "Index";
            }
            else
            {
                string[] requestUrlSplit = request.Url.Split('/', StringSplitOptions.RemoveEmptyEntries);

                if (requestUrlSplit.Length == 2)
                {
                    requestMethod = request.RequestMethod.ToString();
                    controllerName = requestUrlSplit[0];
                    actionName = requestUrlSplit[1];
                }

            }

            var controller = this.GetController(controllerName, request);

            var action = this.GetAction(requestMethod, controller, actionName);

            return this.PrepareResponse(controller, action);
        }

        private IHttpResponse PrepareResponse(Controller controller, MethodInfo action)
        {
            if (controller == null || action == null)
            {
                return null;
            }

            IActionResult actionResult = (IActionResult)action.Invoke(controller, null);
            
            string invocationResult = actionResult.Invoke();

            if (actionResult is IViewable)
            {
                return new HtmlResult(invocationResult, HttpResponseStatusCode.OK);
            }

            if (actionResult is IRedirectable)
            {
                return new RedirectResult(invocationResult);
            }

            throw new InvalidOperationException("This type of result is not supported");
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
                    requestMethod.ToLower() == "get")
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

            if (controllerType!=null)
            {
                controller = (Controller)Activator.CreateInstance(controllerType);
            }
           
            if (controller != null)
            {
               
                controller.Request = request;
            }
      
            return controller;
        }
    }
}
