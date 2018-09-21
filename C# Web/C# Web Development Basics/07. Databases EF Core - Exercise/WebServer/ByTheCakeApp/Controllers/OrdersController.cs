namespace WebServer.ByTheCakeApp.Controllers
{
    using System;
    using System.Linq;
    using System.Globalization;

    using Helpers;
    using Services;

    using Server.HTTP.Contracts;
    using Server.HTTP;
    using Server.HTTP.Response;

    public class OrdersController:Controller
    {
        private readonly IOrderService orderService;

        public OrdersController()
        {
            orderService = new OrderService();
        }

        public IHttpResponse ShowOrders(IHttpRequest request)
        {
            if (!request.Session.Contains(SessionStore.currentUserKey))
            {
                throw new InvalidOperationException("There is no logged in user.");
            }

            var username = request.Session.Get<string>(SessionStore.currentUserKey);

            var userOrders = orderService.GetUserOrders(username);

            if (userOrders == null)
            {
                throw new InvalidOperationException($"The user {username} could not be found in the database");
            }

            var tableRowsWithOrders = userOrders
                           .Select(uo => $@"<tr><td><a href=""/orderDetails/{uo.Id}"">{uo.Id}</a></td> <td>{uo.CreationDate.ToString("dd-MM-yyy", CultureInfo.InvariantCulture)}</td><td>{uo.Sum}</td></tr>");

            string allRows = string.Join(Environment.NewLine, tableRowsWithOrders);

            this.ViewData["tableContent"] = allRows;

            return this.FileViewResponse(@"Orders\UserOrders");
        }

        public IHttpResponse Details(IHttpRequest request)
        {
            int id = int.Parse(request.UrlParameters["id"]);

            var orderDetailsViewModel = this.orderService.Details(id);

            if (orderDetailsViewModel == null)
            {
                return new NotFoundResponse();
            }
            this.ViewData["orderId"] = orderDetailsViewModel.Id.ToString();

            string[] products = orderDetailsViewModel
                        .ProductsWithPrices
                        .Select(p => $@"<tr><td><a href=""/cakeDetails/{p.Id}"">{p.Name}</a></td><td>${p.Price}</td>")
                        .ToArray();
            string allProductsAsString = string.Join(Environment.NewLine, products);

            this.ViewData["tableContent"] = allProductsAsString;
            this.ViewData["creationDate"] = orderDetailsViewModel.CreationDate.ToString("dd-MM-yyyy",CultureInfo.InvariantCulture);

            return this.FileViewResponse(@"Orders\Details");
        }
    }
}
