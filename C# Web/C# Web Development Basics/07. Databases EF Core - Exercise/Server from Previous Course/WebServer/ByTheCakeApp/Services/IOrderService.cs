namespace WebServer.ByTheCakeApp.Services
{
    using System.Collections.Generic;
    using ViewModels.Orders;

    public interface IOrderService
    {
        IEnumerable<UserOrdersListingViewModel> GetUserOrders(string username);

        OrderDetailsViewModel Details(int id);
    }
}
