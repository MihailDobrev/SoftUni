using CHUSHKA.Web.Services.Contracts;
using CHUSHKA.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CHUSHKA.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [Authorize(Roles = ("Admin"))]
        public IActionResult All()
        {
            List<OrdersAllViewModel> model = this.orderService.GetAllOrders().ToList();

            return View(model);
        }
    }
}
