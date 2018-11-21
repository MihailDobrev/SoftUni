using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CHUSHKA.Web.Models;
using CHUSHKA.Web.Services.Contracts;
using CHUSHKA.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
//using CHUSHKA.Web.Models;

namespace CHUSHKA.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            List<ProductPartialViewModel> model = new List<ProductPartialViewModel>();

            model = this.productService.GetAllProducts().ToList();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
