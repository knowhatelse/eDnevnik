using System.ComponentModel.DataAnnotations;

namespace eDnevnik___backend.DTOs.AuthenticationDto;

public class RegisterDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
}