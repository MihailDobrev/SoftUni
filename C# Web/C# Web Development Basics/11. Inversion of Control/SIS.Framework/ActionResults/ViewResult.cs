namespace SIS.Framework.ActionResults
{
    using SIS.Framework.ActionResults.Contracts;

    public class ViewResult : IViewable
    {
        public IRenderable View { get; set; }

        public ViewResult(IRenderable view)
        {
            this.View = view;
        }

        public string Invoke()
            => this.View.Render();
    }
}
