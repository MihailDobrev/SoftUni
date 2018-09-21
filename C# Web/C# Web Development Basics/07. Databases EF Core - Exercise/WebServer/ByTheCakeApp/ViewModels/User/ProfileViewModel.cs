namespace WebServer.ByTheCakeApp.ViewModels.User
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProfileViewModel
    {
        public string Username { get; set; }

        public DateTime RegistrationDate { get; set; }

        public int TotalOrders { get; set; }
    }
}
