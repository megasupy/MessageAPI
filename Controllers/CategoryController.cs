using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;
namespace api.Controllers;

public class CategoryController : ControllerBase
{
    private IRepository<Category, int> repository;

    public CategoryController(IRepository<Category, int> r)
    {
        repository = r;
    }

    public IActionResult Index()
    {
        var categories = repository.Get();
        return Ok(categories);
    }

    [HttpGet]
    public IActionResult Create()
    {
        var category = new Category();
        return Ok(category);
    }

    [HttpPost]
    public IActionResult Create(Category c)
    {
        repository.Create(c);
        return RedirectToAction("Index");
    }
}