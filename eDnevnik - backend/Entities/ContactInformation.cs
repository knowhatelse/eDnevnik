using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eDnevnik___backend.Entities;

public class ContactInformation
{
    [Key]
    public int Id { get; set; }
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    
    [ForeignKey("User")]
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}