using System.ComponentModel.DataAnnotations;

namespace api.Models;

public class Message
{
    [Key]
    public Guid MessageId { get; set; } = Guid.NewGuid();

    [Required]
    public string MessageText { get; set; }

    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Email { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
