namespace eDnevnik___backend.DTOs.AuthenticationDto;

public class AccountVerificationDto
{
    public string VerificationToken { get; set; } = null!;
    public string UserEmail { get; set; } = null!;
    public string UserName { get; set; } = null!;
}