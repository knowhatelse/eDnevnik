using System.Text.Json.Serialization;
using eDnevnik___backend.DTOs.UserDto;

namespace eDnevnik___backend.DTOs.AdminDto;

public class UpdateAdminDto: UpdateUserDto
{
    [JsonIgnore]
    public string? VerificationToken { get; set; }
    [JsonIgnore]
    public bool IsVerified { get; set; } = true;
}