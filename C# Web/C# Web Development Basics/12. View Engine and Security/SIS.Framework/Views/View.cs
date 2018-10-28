namespace SIS.Framework.Views
{
    using SIS.Framework.ActionResults.Contracts;

    public class View: IRenderable
    {
        private readonly string fullHtmlContent;

        public View(string fullHtmlContent)
        {
            this.fullHtmlContent = fullHtmlContent;
        }

        public string Render()
        => this.fullHtmlContent;

    }
}
