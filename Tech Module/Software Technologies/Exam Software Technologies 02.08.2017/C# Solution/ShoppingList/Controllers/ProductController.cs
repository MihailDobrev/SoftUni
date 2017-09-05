using System.Linq;
using System.Web.Mvc;
using ShoppingList.Models;

namespace ShoppingList.Controllers
{
    [ValidateInput(false)]
    public class ProductController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var db = new ShoppingListDbContext())
            {
                var products = db.Products.ToList();
                return View(products);
            }

        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (product == null)
            {
                return RedirectToAction("Index");
            }

            using (var db = new ShoppingListDbContext())
            {
                db.Products.Add(product);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int? id)
        {
            using (var db = new ShoppingListDbContext())
            {
                var product = db.Products.Find(id);

                if (product != null)
                {
                    return View(product);
                }
            }
            return Redirect("/");

        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int? id, Product productModel)
        {
            if (!ModelState.IsValid)
            {
                return View(productModel);
            }

            using (var db = new ShoppingListDbContext())
            {
                var productFromDb = db.Products.Find(productModel.Id);
                if (productFromDb != null)
                {
                    productFromDb.Priority = productModel.Priority;
                    productFromDb.Name = productModel.Name;
                    productFromDb.Quantity = productModel.Quantity;
                    productFromDb.Status = productModel.Status;
                    db.SaveChanges();
                }
            }
            return Redirect("/");

        }
    }
}