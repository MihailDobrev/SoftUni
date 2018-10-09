namespace WebServer.ByTheCakeApp.Services
{
    using System.Collections.Generic;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using ViewModels.Orders;
    using ViewModels.Products;

    public class OrderService : IOrderService
    {
        public IEnumerable<UserOrdersListingViewModel> GetUserOrders(string username)
        {
            using (var db = new ByTheCakeDbContext())
            {
                var userOrders = db.Orders
                    .Include(o => o.User)
                    .Where(o => o.User.Username == username)
                    .Select(o => new UserOrdersListingViewModel
                    {
                        Id = o.Id,
                        CreationDate = o.CreationDate,
                        Sum = o.OrderProducts.Sum(op => op.Product.Price)
                    })
                    .OrderByDescending(u => u.CreationDate)
                    .ToArray();

                return userOrders;
            }
        }

        public OrderDetailsViewModel Details(int id)
        {
            using (var db = new ByTheCakeDbContext())
            {
                var orderWithProducts = db.Orders
                    .Where(o => o.Id == id)
                    .Select(o => new
                    {
                        OrderId = o.Id,
                        Products = o.OrderProducts.Select(op => new ProductListingViewModel
                        { 
                            Id=op.ProductId,
                            Name = op.Product.Name,
                            Price = op.Product.Price
                        }).ToArray(),
                        CreationDate = o.CreationDate
                    })
                    .ToArray()
                    .Select(o => new OrderDetailsViewModel
                    {
                        Id = o.OrderId,
                        ProductsWithPrices = o.Products,
                        CreationDate = o.CreationDate
                    }).FirstOrDefault();

                return orderWithProducts;
            }
        }
    }
}
