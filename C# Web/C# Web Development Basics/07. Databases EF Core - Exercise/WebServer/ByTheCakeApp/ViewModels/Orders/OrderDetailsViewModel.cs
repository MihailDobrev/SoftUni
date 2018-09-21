namespace WebServer.ByTheCakeApp.ViewModels.Orders
{
    using System;
    using ViewModels.Products;

    public class OrderDetailsViewModel
    {
        public int Id { get; set; }

        public ProductListingViewModel[] ProductsWithPrices { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
