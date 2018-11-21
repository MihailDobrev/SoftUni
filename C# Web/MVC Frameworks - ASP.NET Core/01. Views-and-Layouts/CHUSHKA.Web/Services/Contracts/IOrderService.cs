using CHUSHKA.Web.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CHUSHKA.Web.Services.Contracts
{
    public interface IOrderService
    {
        Task<int> CreateOrder(string productId, string clientId);

        IEnumerable<OrdersAllViewModel> GetAllOrders();
    }
}
