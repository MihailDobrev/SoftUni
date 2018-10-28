namespace IRunesWebApp.ViewModels
{
    using System.Collections.Generic;

    public class LoginViewModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public IEnumerable<NestedViewModel> NestedViewModels { get; set; }
    }
}
