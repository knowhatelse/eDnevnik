using System.Text.Json.Serialization;

namespace eDnevnik___backend.DTOs.VerificationDto;

public class VerificationResponseDto
{
    public int? UserId { get; set; }
    public string? Role { get; set; }
    public int StatusCode { get; set; }
    public string StatusMessage { get; set; } = null!;
    public string? JwtToken { get; set; }

}