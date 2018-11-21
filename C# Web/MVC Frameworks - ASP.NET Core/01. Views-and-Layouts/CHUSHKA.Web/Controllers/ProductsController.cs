using CHUSHKA.Models;
using CHUSHKA.Web.Models;
using CHUSHKA.Web.Services.Contracts;
using CHUSHKA.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CHUSHKA.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly IOrderService orderService;
        private UserManager<User> userManager;

        public ProductsController(IProductService productService, IOrderService orderService, UserManager<User> userManager)
        {
            this.productService = productService;
            this.orderService = orderService;
            this.userManager = userManager;
        }

        [Authorize(Roles = ("Admin"))]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = ("Admin"))]
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateViewModel model)
        {
            int result = await this.productService.CreateProcuct(model);

            if (result == 1)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize]
        public async Task<IActionResult> Order(string productId)
        {
            string userId = this.userManager.GetUserId(this.User);

            int result = await this.orderService.CreateOrder(productId, userId);

            if (result == 1)
            {
                return RedirectToAction("Index", "Home");
            }

            return BadRequest();
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var product = this.productService.GetProductById(id);

            if (product == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new ProductDetailsViewModel
            {
                Id = id,
                Name = product.Name,
                Price = product.Price.ToString(),
                Description = product.Description,
                Type = product.Type.ToString()
            };

            return this.View(model);
        }

        [Authorize(Roles = ("Admin"))]
        public IActionResult Edit(string productId)
        {
            var product = this.productService.GetProductById(productId);

            if (product == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new ProductUpdateDeleteViewModel
            {
                Id = productId,
                Name = product.Name,
                Price = product.Price.ToString(),
                Description = product.Description,
                Type = product.Type.ToString()
            };

            return this.View(model);
        }

        [Authorize(Roles = ("Admin"))]
        [HttpPost]
        public async Task<IActionResult> Edit(ProductUpdateDeleteViewModel model)
        {
            int result = await this.productService.Edit(model);

            if (result == 1)
            {
                return RedirectToAction("Details", "Products", new { id = model.Id });
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = ("Admin"))]
        public IActionResult Delete(string productId)
        {
            var product = this.productService.GetProductById(productId);

            if (product == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new ProductUpdateDeleteViewModel
            {
                Id = productId,
                Name = product.Name,
                Price = product.Price.ToString(),
                Description = product.Description,
                Type = product.Type.ToString()
            };

            return this.View(model);
        }

        [Authorize(Roles = ("Admin"))]
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DoDelete(string id)
        {
            this.productService.Delete(id);

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
