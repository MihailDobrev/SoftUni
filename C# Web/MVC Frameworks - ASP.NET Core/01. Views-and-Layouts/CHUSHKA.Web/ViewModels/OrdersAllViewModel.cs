using System;

namespace CHUSHKA.Web.ViewModels
{
    public class OrdersAllViewModel
    {
        public string Id { get; set; }

        public DateTime OrderedOn { get; set; }

        public string ProductName { get; set; }

        public string ClientName { get; set; }
    }
}
