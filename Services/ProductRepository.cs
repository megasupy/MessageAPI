using api.Models;
using System.Collections;
namespace api.Services;

public class ProductRepository : IRepository<Product, int>
{
    SalesDbContext context;

    public ProductRepository(SalesDbContext ctx)
    {
        context = ctx;
    }

    public void Create(Product entity)
    {
        context.Products.Add(entity);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        var prd = context.Products.Find(id);

        if (prd == null)
        {
            throw new Exception("Product record is not found");
        }
        else
        {
            context.Products.Remove(prd);
            context.SaveChanges();
        }
    }

    public IEnumerable Get()
    {
        return context.Products.ToList();
    }

    public Product Get(int id)
    {
        var prd = context.Products.Find(id);

        if (prd == null)
        {
            throw new Exception("Product record is not found");
        }

        return prd;
    }

    public void Update(int id, Product entity)
    {
        var prd = context.Products.Find(id);

        if (prd == null)
        {
            throw new Exception("Product record is not found");
        }
        else
        {
            prd.ProductName = entity.ProductName;
            prd.Price = entity.Price;
            prd.CategoryId = entity.CategoryId;
            context.SaveChanges();
        }
    }
}