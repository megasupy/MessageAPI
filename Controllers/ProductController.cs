using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;
 
namespace api.Controllers
{
    public class ProductController : ControllerBase
    {
        IRepository<Product, int> repoCat;
        IRepository<Product, int> repository;
        public ProductController(IRepository<Product, int> rc,IRepository<Product, int> r)
        {
            repoCat = rc;
            repository = r;
        }
 
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Get()
        {
            var products = repository.Get();
            return Ok(products);
        }
        public IActionResult Create()
        {
            var categoryNames = repoCat.Get();
            return Ok(new {Product = new Product(), Categories = categoryNames});
        }
        [HttpPost]
        public IActionResult Create(Product prd)
        {
            try
            {
                repository.Create(prd);
                return RedirectToAction("Index");
            }
            catch
            {
                var categoryNames = repoCat.Get();
                return Ok(new {Product = new Product(), Categories = categoryNames});
            }
        }
     
        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}