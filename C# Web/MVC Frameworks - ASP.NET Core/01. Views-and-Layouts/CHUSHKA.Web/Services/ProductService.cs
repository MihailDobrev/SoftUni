using CHUSHKA.Data;
using CHUSHKA.Models;
using CHUSHKA.Models.Enums;
using CHUSHKA.Web.Services.Contracts;
using CHUSHKA.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHUSHKA.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext context;

        public ProductService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateProcuct(ProductCreateViewModel model)
        {
            Product product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                Type = (ProductType)Enum.Parse(typeof(ProductType), model.Type)
            };

            this.context.Products.Add(product);

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

        public async Task<int> Edit(ProductUpdateDeleteViewModel model)
        {
            var product = this.context.Products.FirstOrDefault(p => p.Id == model.Id);

            if (product == null)
            {
                return 0;
            }

            product.Name = model.Name;
            product.Description = model.Description;
            product.Type = (ProductType)Enum.Parse(typeof(ProductType), model.Type);
            product.Price = decimal.Parse(model.Price);

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

        public void Delete(string id)
        {
            var product = this.context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return;
            }

            this.context.Products.Remove(product);

            this.context.SaveChanges();
        }

        public bool ExistsProduct(string productId)
        {
            return this.context.Products.Any(p => p.Id == productId);
        }

        public Product GetProductById(string id)
        {
            return this.context.Products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<ProductPartialViewModel> GetAllProducts()
        {
            return this.context.Products.Select(p => new ProductPartialViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price.ToString(),
                Description = p.Description.Length > 50 ? p.Description.Substring(0, 50) + "..." : p.Description
            });
        }
    }
}
