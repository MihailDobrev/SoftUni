namespace WebServer.ByTheCakeApp.ViewModels.Orders
{
    using System;

    public class UserOrdersListingViewModel
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public decimal Sum { get; set; }
    }
}
