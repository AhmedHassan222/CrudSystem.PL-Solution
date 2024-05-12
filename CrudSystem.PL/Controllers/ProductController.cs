using CrudSystem.BLL.InterfacesRepositiries;
using CrudSystem.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudSystem.PL.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepo _productRepo;
        public ProductController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        public IActionResult Index()
        {
            var products = _productRepo.GetAllProducts();
            ViewBag.Message = products;
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            //check validation first  (server side validation)
            // model state
            if (ModelState.IsValid)
            {
                _productRepo.Add(product);
                return RedirectToAction(nameof(Index));

            }
            return View(product);
            
            
        }
        public IActionResult Details(int? id , string viewName ="Details")
        {
            if (id is null)
                return BadRequest();
            var product = _productRepo.GetProductById(id.Value);
            if(product is null)
                return NotFound();
            return View(viewName ,product);

        }
        public IActionResult Update(int? id)
        {
            return Details(id , "Update");

        }
        [HttpPost] 
        public IActionResult Update([FromRoute] int id ,Product product)
        {
            if (id != product.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    _productRepo.Update(product);
                    return RedirectToAction(nameof(Index));

                }catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                

            }
            return View(product);

        }

        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            try
            {
                _productRepo.Delete(product);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(product);
        }
    }

}
