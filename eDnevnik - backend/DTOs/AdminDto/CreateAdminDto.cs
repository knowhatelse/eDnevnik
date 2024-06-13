using System.Text.Json.Serialization;
using eDnevnik___backend.DTOs.UserDto;

namespace eDnevnik___backend.DTOs.AdminDto;

public class CreateAdminDto: CreateUserDto
{
    [JsonIgnore]
    public new int? SchoolId { get; set; } = null;
    [JsonIgnore]
    public string? VerificationToken { get; set; }
    [JsonIgnore]
    public bool IsVerified { get; set; }
}