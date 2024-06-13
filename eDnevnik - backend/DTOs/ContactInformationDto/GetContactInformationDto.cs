namespace eDnevnik___backend.DTOs.ContactInformationDto;

public class GetContactInformationDto
{
    public int Id { get; set; }
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public int UserId { get; set; }
}