namespace WebServer.ByTheCakeApp.Services
{
    using System.Collections.Generic;
    using ViewModels.Products;

    public interface IProductService
    {
        void Create(string name, decimal price, string imageUrl);

        IEnumerable<ProductListingViewModel> All(string searchTerm);

        ProductDetailsViewModel Find(int id);

        IEnumerable<ProductCartViewModel> FindProductsInCart(IEnumerable<int> ids);

        bool Exists(int id);
    }
}
