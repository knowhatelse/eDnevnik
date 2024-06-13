namespace eDnevnik___backend.DTOs.VerificationDto;

public class TokenVerificationDto
{
    public int UserId { get; set; }
    public string VerificationToken { get; set; } = null!;
}