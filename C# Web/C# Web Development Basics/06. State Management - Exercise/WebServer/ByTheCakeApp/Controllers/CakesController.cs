namespace WebServer.ByTheCakeApp.Controllers
{
    using System;
    using System.Linq;
    using ByTheCakeApp.Data;
    using ByTheCakeApp.Helpers;
    using ByTheCakeApp.Models;
    using Server.HTTP.Contracts;

    public class CakesController : Controller
    {

        private readonly CakesData cakesData;

        public CakesController()
        {
            this.cakesData = new CakesData();
        }
        public IHttpResponse Add()
        {
            this.ViewData["showResult"] = "none";

            return this.FileViewResponse(@"Cakes\Add");
        }

        public IHttpResponse Add(string name, string price)
        {

            var cake = new Cake()
            {
                Name = name,
                Price = decimal.Parse(price)
            };

            this.cakesData.Add(name, price);

            this.ViewData["name"] = name;
            this.ViewData["price"] = price;
            this.ViewData["showResult"] = "block";

            return this.FileViewResponse(@"Cakes\Add");
        }

        public IHttpResponse Search(IHttpRequest req)
        {
            const string searchTermKey = "searchTerm";

            var querryParameters = req.QuerryParameters;

            this.ViewData["results"] = string.Empty;
            this.ViewData["searchTerm"] = string.Empty;

            if (querryParameters.ContainsKey(searchTermKey))
            {
                var searchTerm = querryParameters[searchTermKey];

                this.ViewData["searchTerm"] = searchTerm;

                var savedCakesDivs = this.cakesData.All()
                    .Where(c => c.Name.ToLower().Contains(searchTerm.ToLower()))
                    .Select(c => $@"<div>Name: {c.Name} - Price: ${c.Price:F2} <a href=""/shopping/add/{c.Id}?searchTerm={searchTerm}"">Order</a></div>");

                var results = "No Cakes found!";

                if (savedCakesDivs.Any())
                {
                    results = string.Join(Environment.NewLine, savedCakesDivs);
                }
              

                this.ViewData["results"] = results;
            }
            else
            {
                this.ViewData["results"] = "Please enter search term";
            }
          
            this.ViewData["showCart"] = "none";

            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            if (shoppingCart.Orders.Any())
            {
                var totalProducts = shoppingCart.Orders.Count;
                var totalProductsText = totalProducts != 1 ? "products" : "product";

                this.ViewData["showCart"] = "block";
                this.ViewData["products"] = $"{totalProducts} {totalProductsText}";
            }

            return this.FileViewResponse(@"Cakes\Search");
        }
    }
}
