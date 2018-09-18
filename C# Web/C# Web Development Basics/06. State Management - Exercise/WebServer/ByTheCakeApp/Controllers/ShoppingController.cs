namespace WebServer.ByTheCakeApp.Controllers
{
    using System.Linq;
    using ByTheCakeApp.Data;
    using ByTheCakeApp.Helpers;
    using ByTheCakeApp.Models;
    using Server.HTTP.Contracts;
    using Server.HTTP.Response;

    public class ShoppingController : Controller
    {
        private readonly CakesData cakesData;

        public ShoppingController()
        {
            this.cakesData = new CakesData();
        }

        public IHttpResponse AddToCart(IHttpRequest request)
        {
            int id = int.Parse(request.UrlParameters["id"]);

            var cake = this.cakesData.Find(id);

            if (cake == null)
            {
                return new NotFoundResponse();
            }

            var shoppingcart = request.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            shoppingcart.Orders.Add(cake);

            var redirectUrl = "/search";

            const string searchTermKey = "searchTerm";

            if (request.UrlParameters.ContainsKey(searchTermKey))
            {
                redirectUrl = $"{redirectUrl}?{searchTermKey}={request.UrlParameters[searchTermKey]}";
            }

            return new RedirectResponse(redirectUrl);
        }

        public IHttpResponse ShowCart(IHttpRequest request)
        {
            var shoppingCart = request.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            if (!shoppingCart.Orders.Any())
            {
                this.ViewData["cartItems"] = "No items in your cart";
                this.ViewData["totalCost"] = "0";
            }
            else
            {
                var items = shoppingCart
                    .Orders
                    .Select(o => $"<div>{o.Name} - ${o.Price:F2}</div> <br />");

                this.ViewData["cartItems"] = string.Join(string.Empty, items);

                var totalPrice = shoppingCart
                    .Orders
                    .Sum(o => o.Price);

                this.ViewData["totalCost"] = $"{totalPrice:F2}";
            }

            return this.FileViewResponse(@"Shopping\Cart");
        }

        public IHttpResponse FinishOrder(IHttpRequest req)
        {
            req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey).Orders.Clear();
            return this.FileViewResponse(@"Shopping\Finish-order");
        }
    }
}
