namespace SIS.Framework.Utilities
{
    using SIS.Framework.Controllers;

    public static class ControllerUtilities
    {
        public static string GetControllerName(Controller controller)
          => controller
                .GetType()
                .Name
                .Replace(MvcContext.Get.ControllerSuffix, string.Empty);

        public static string GetViewFullQualifiedName(string controllerName, string action)
                => string.Format("..\\..\\..\\{0}\\{1}\\{2}.html", MvcContext.Get.ViewsFolder, controllerName, action);

    }
}