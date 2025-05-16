using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace api.Models;

public class Category
{
    [Required(ErrorMessage = "Category Id is Required")]
    public int CategoryId { get; set; }
    [Required(ErrorMessage = "Category Name is Required")]
    public int CategoryName { get; set; }
}