namespace WebServer.ByTheCakeApp.Models
{
    using System.Collections.Generic;

    public class ShoppingCart
    {
        public const string SessionKey = "Current_Shopping_Cart";

        public List<Cake> Orders { get; set; } = new List<Cake>();
    }
}
