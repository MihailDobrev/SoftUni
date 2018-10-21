namespace SIS.Framework.Views
{
    using SIS.Framework.ActionResults.Contracts;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class View: IRenderable
    {
        private readonly string fullyQualifiedTemplateName;
        private readonly IDictionary<string, object> viewData;

        public View(string fullyQualifiedTemplateName, IDictionary<string,object> viewData)
        {
            this.fullyQualifiedTemplateName = fullyQualifiedTemplateName;
            this.viewData = viewData;
        }

        private string ReadFile()
        {
            if (!File.Exists(this.fullyQualifiedTemplateName))
            {
                throw new FileNotFoundException($"View does not exist at {fullyQualifiedTemplateName}");
            }

            return File.ReadAllText(this.fullyQualifiedTemplateName);
        }

        public string Render()
        {
            var fullHtml = this.ReadFile();
            string renderedHtml = this.RenderHtml(fullHtml);
            var layoutWithView = this.AddViewToLayout(renderedHtml);

            return layoutWithView;
        }

        private string AddViewToLayout(string renderedHtml)
        {
            string layoutViewPath =
                           MvcContext.Get.RootDirectoryRelativePath + // ../../../
                           MvcContext.Get.ViewsFolderName +  // Views
                           MvcContext.DirectorySeparator + // /
                           MvcContext.Get.LayoutViewName + // /_Layout
                           MvcContext.HtmlFileExtension; // .html;

            if (!File.Exists(layoutViewPath))
            {
                throw new FileNotFoundException($"Layout view does not exist at {fullyQualifiedTemplateName}");
            }

            var layoutViewContent = File.ReadAllText(layoutViewPath);
            var layoutWithView = layoutViewContent.Replace(MvcContext.Get.Content,renderedHtml);
            return layoutWithView;
        }

        private string RenderHtml(string fullHtml)
        {
            string renderedHtml = fullHtml;

            if (this.viewData.Any())
            {
                foreach (var parameter in this.viewData)
                {
                    renderedHtml = renderedHtml.Replace($"{{{{{{{parameter.Key}}}}}}}", parameter.Value.ToString());
                }
            }

            return renderedHtml;
        }
    }
}
