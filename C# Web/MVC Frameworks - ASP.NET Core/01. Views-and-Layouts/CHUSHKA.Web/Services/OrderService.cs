using CHUSHKA.Data;
using CHUSHKA.Models;
using CHUSHKA.Web.Services.Contracts;
using CHUSHKA.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHUSHKA.Web.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext context;

        public OrderService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateOrder(string productId, string clientId)
        {
            Order order = new Order
            {
                OrderedOn = DateTime.UtcNow,
                ProductId = productId,
                ClientId = clientId
            };

            this.context.Orders.Add(order);

            try
            {
                int result = await this.context.SaveChangesAsync();
                return result;
            }
            catch (Exception)
            {
                throw new InvalidOperationException();
            }
        }

        public IEnumerable<OrdersAllViewModel> GetAllOrders()
        {
            return this.context.Orders.Select(o => new OrdersAllViewModel
            {
                Id = o.Id,
                OrderedOn = o.OrderedOn,
                ProductName = o.Product.Name,
                ClientName = o.Client.UserName
            });
        }
    }
}
