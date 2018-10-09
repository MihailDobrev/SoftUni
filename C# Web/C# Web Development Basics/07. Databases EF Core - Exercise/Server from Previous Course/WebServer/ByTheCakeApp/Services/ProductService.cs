namespace WebServer.ByTheCakeApp.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Data.Models;
    using WebServer.ByTheCakeApp.ViewModels.Products;

    public class ProductService : IProductService
    {
        public void Create(string name, decimal price, string imageUrl)
        {
            using (var db = new ByTheCakeDbContext())
            {
                var product = new Product
                {
                    Name = name,
                    Price = price,
                    ImageURL = imageUrl
                };

                db.Products.Add(product);
                db.SaveChanges();
            }

        }

        public IEnumerable<ProductListingViewModel> All(string searchTerm = null)
        {
            using (var db = new ByTheCakeDbContext())
            {
                var resultsQuerry = db.Products.AsQueryable();

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    resultsQuerry = resultsQuerry
                        .Where(p => p.Name.ToLower().Contains(searchTerm.ToLower()));
                }

                return resultsQuerry
                   .Select(p => new ProductListingViewModel
                   {
                       Id = p.Id,
                       Name = p.Name,
                       Price = p.Price
                   })
                   .ToList();
            }
        }

        public ProductDetailsViewModel Find(int id)
        {
            using (var db = new ByTheCakeDbContext())
            {
                return db
                    .Products
                    .Where(p => p.Id == id)
                    .Select(p => new ProductDetailsViewModel
                    {
                        Name = p.Name,
                        Price = p.Price,
                        ImageUrl = p.ImageURL
                    })
                    .FirstOrDefault();
            }
        }

        public bool Exists(int id)
        {
            using (var db = new ByTheCakeDbContext())
            {
                return db.Products.Any(pr => pr.Id == id);
            }
        }

        public IEnumerable<ProductCartViewModel> FindProductsInCart(IEnumerable<int> ids)
        {
            using (var db = new ByTheCakeDbContext())
            {
                return db.Products
                    .Where(p => ids.Contains(p.Id))
                    .Select(pr => new ProductCartViewModel
                    {
                        Name = pr.Name,
                        Price = pr.Price
                    })
                    .ToList();
            }
        }
    }
}
