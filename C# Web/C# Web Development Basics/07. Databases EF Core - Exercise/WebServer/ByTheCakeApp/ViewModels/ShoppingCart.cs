namespace WebServer.ByTheCakeApp.Models
{
    using System.Collections.Generic;

    public class ShoppingCart
    {
        public const string SessionKey = "Current_Shopping_Cart";

        public List<int> ProductsIds { get; set; } = new List<int>();
    }
}
