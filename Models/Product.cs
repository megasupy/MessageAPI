using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace api.Models;

public class Product
{
    [Required(ErrorMessage = "Product Id is Required")]
    public int ProductId { get; set; }
    [Required(ErrorMessage = "Product Name is Required")]
    public string ProductName { get; set; }
    [Required(ErrorMessage = "Product Manufacturer is Required")]
    public string Manufacturer { get; set; }
    [Required(ErrorMessage = "Product Price is Required")]
    public int Price { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}