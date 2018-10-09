namespace WebServer.ByTheCakeApp.Controllers
{
    using System;
    using System.Linq;

    using Helpers;
    using Models;
    using ViewModels.Products;
    using Services;

    using Server.HTTP.Contracts;
    using Server.HTTP.Response;

    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private const string AddView = @"Products\Add";

        public ProductsController()
        {
            productService = new ProductService();
        }
        public IHttpResponse Add()
        {
            this.ViewData["showResult"] = "none";

            return this.FileViewResponse(AddView);
        }

        public IHttpResponse Add(ProductsViewModel model)
        {
            string name = model.Name;
            decimal price = model.Price;
            string imageUrl = model.ImageUrl;

            if (name.Length < 3 ||
                name.Length > 30 ||
                imageUrl.Length < 3 ||
                imageUrl.Length > 2000)
            {
                this.ViewData["showResult"] = "block";
                this.ViewData["error"] = "Invalid user details";

                return this.FileViewResponse(AddView);
            }

            this.productService.Create(name, price, imageUrl);

            this.ViewData["name"] = name;
            this.ViewData["price"] = price.ToString();
            this.ViewData["imageUrl"] = imageUrl;
            this.ViewData["showResult"] = "block";

            return this.FileViewResponse(AddView);
        }

        public IHttpResponse Search(IHttpRequest req)
        {
            const string searchTermKey = "searchTerm";

            var querryParameters = req.QuerryParameters;

            this.ViewData["results"] = string.Empty;

            var searchTerm = querryParameters.ContainsKey(searchTermKey)
                ? querryParameters[searchTermKey]
                : null;

            this.ViewData["searchTerm"] = searchTerm;

            var searchedProducts = this.productService.All(searchTerm);

            if (searchedProducts.Any())
            {
                var allProducts = searchedProducts
                      .Select(c => $@"<div>Name: <a href=""/cakeDetails/{c.Id}""> {c.Name}</a> - Price: ${c.Price:F2} <a href=""/shopping/add/{c.Id}?searchTerm={searchTerm}"">Order</a></div>");

                var allProductsAsString = string.Join(Environment.NewLine, allProducts);

                this.ViewData["searchTerm"] = searchTerm;
                this.ViewData["results"] = allProductsAsString;
            }
            else
            {
                this.ViewData["results"] = "No cakes found";
            }

            this.ViewData["showCart"] = "none";

            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            if (shoppingCart.ProductsIds.Any())
            {
                var totalProducts = shoppingCart.ProductsIds.Count;
                var totalProductsText = totalProducts != 1 ? "products" : "product";

                this.ViewData["showCart"] = "block";
                this.ViewData["products"] = $"{totalProducts} {totalProductsText}";
            }

            return this.FileViewResponse(@"Products\Search");
        }

        public IHttpResponse Details(IHttpRequest request)
        {
            int id = int.Parse(request.UrlParameters["id"]);

            ProductDetailsViewModel product = this.productService.Find(id);

            if (product == null)
            {
                return new NotFoundResponse();
            }

            this.ViewData["name"] = product.Name;
            this.ViewData["price"] = product.Price.ToString("F2");
            this.ViewData["imageUrl"] = product.ImageUrl;

            return this.FileViewResponse(@"Products\CakeDetails");
        }
    }
}
