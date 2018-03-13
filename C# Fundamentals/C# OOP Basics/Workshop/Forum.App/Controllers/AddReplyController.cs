namespace Forum.App.Controllers
{
    using Forum.App.Controllers.Contracts;
    using Forum.App.Services;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.UserInterface.Input;
    using Forum.App.UserInterface.ViewModels;
    using Forum.App.Views;
    using System.Linq;

    public class AddReplyController : IController
    {
        private const int TEXT_AREA_WIDTH = 37;
        private const int TEXT_AREA_HEIGHT = 6;
        private const int POST_MAX_LENGTH = 220;

        private static int centerTop = Position.ConsoleCenter().Top;
        private static int centerLeft = Position.ConsoleCenter().Left;
        public bool Error { get; set; }
        public ReplyViewModel Reply { get; private set; }

        private PostViewModel postViewModel;
        private TextArea TextArea { get; set; }
        public int PostId { get; private set; }
        public AddReplyController()
        {
            ResetReply();
        }
        private enum Command
        {
            Write, Submit, Back
        }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.Write:
                    this.TextArea.Write();
                    Reply.Content = TextArea.Lines.ToArray();
                    return MenuState.AddReply;
                case Command.Submit:
                    bool validReply = PostService.TrySaveReply(Reply,postViewModel.PostId);
                    if (!validReply)
                    {
                        this.Error = true;
                        return MenuState.Rerender;
                    }
                    return MenuState.ReplyAdded;
                case Command.Back:
                    return MenuState.Back;
            }
            throw new InvalidCommandException();
        }

        public IView GetView(string userName)
        {
            return new AddReplyView(postViewModel,this.Reply, this.TextArea, this.Error);
        }
        public void ResetReply()
        {
            this.Error = false;
            this.Reply = new ReplyViewModel();
            int contentLength = postViewModel?.Content.Count ?? 0;
            this.TextArea = new TextArea(centerLeft - 18, centerTop +contentLength- 6, TEXT_AREA_WIDTH, TEXT_AREA_HEIGHT, POST_MAX_LENGTH);
        }


        public void SetPostId(int postId, string username)
        {
            PostId = postId;
            postViewModel = PostService.GetPostViewModel(postId);
            ResetReply();
            Reply.Author = username;
        }
    }
}
