using CHUSHKA.Models;
using CHUSHKA.Web.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CHUSHKA.Web.Services.Contracts
{
    public interface IProductService
    {
        Task<int> CreateProcuct(ProductCreateViewModel model);

        bool ExistsProduct(string productId);

        Product GetProductById(string id);

        Task<int> Edit(ProductUpdateDeleteViewModel model);

        void Delete(string id);

        IEnumerable<ProductPartialViewModel> GetAllProducts();
    }
}
