namespace Forum.App.Controllers
{
    using Forum.App;
    using Forum.App.Controllers.Contracts;
    using Forum.App.Services;
    using Forum.App.UserInterface;
    using Forum.App.UserInterface.Contracts;

    public class SignUpController : IController, IReadUserInfoController
    {
        private const string DETAILS_ERROR = "Invalid Username or Password!";
        private const string USERNAME_TAKEN_ERROR = "Username already in use!";

        public string Username { get; set; }

        private string Password { get; set; }

        public string ErrorMessage { get; set; }

        private enum Command
        {
            ReadUsername, ReadPassword, SignUp, Back
        }

        public enum SignUpStatus
        {
            Success, DetailsError, UsernameTakenError
        }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.ReadUsername:
                    this.ReadUsername();
                    return MenuState.Signup;
                case Command.ReadPassword:
                    this.ReadPassword();
                    return MenuState.Signup;
                case Command.SignUp:
                    SignUpStatus signUp = UserService.TrySignUpUser(this.Username, this.Password);
                    switch (signUp)
                    {
                        case SignUpStatus.Success:
                            return MenuState.SuccessfulLogIn;
                        case SignUpStatus.DetailsError:
                            this.ErrorMessage = DETAILS_ERROR;
                            return MenuState.Error;
                        case SignUpStatus.UsernameTakenError:
                            this.ErrorMessage = USERNAME_TAKEN_ERROR;
                            return MenuState.Error;
                    }
                  return MenuState.Error;
                case Command.Back:
                    return MenuState.Back;
            }

            throw new System.InvalidOperationException();
        }

        public IView GetView(string userName)
        {
            return new SignUpView(ErrorMessage);
        }

        public void ReadPassword()
        {
            Password = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        public void ReadUsername()
        {
            Username = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        public void ResetSignUp()
        {
            ErrorMessage = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
        }
    }
}
