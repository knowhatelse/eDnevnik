using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eDnevnik___backend.Entities;

public class Email
{
    [Key]
    public int Id { get; set; }
    public string Subject { get; set; } = null!;
    public string Content { get; set; } = null!;
    
    [ForeignKey("User")]
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}