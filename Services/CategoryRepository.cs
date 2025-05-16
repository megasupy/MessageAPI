using api.Models;
using System.Collections;
namespace api.Services;

public class CategoryRepository : IRepository<Category, int>
{
    private SalesDbContext context;

    public CategoryRepository(SalesDbContext c)
    {
        context = c;
    }

    public void Create(Category entity)
    {
        context.Categories.Add(entity);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        var cat = context.Categories.Find(id);

        if (cat == null)
        {
            throw new Exception("Category Record not found");
        }
        else
        {
            context.Categories.Remove(cat);
            context.SaveChanges();
        }
    }

    public IEnumerable Get()
    {
        return context.Categories.ToList();
    }

    public Category Get(int id)
    {
        var cat = context.Categories.Find(id);

        if (cat == null)
        {
            throw new Exception("Category Record not found");
        }
        else
        {
            return cat;
        }
    }

    public void Update(int id, Category entity)
    {
        var cat = context.Categories.Find(id);

        if (cat == null)
        {
            throw new Exception("Category record not found");
        }
        else
        {
            cat.CategoryName = entity.CategoryName;
            context.SaveChanges();
        }
    }
}