using System.Text.Json.Serialization;
using eDnevnik___backend.DTOs.UserDto;

namespace eDnevnik___backend.DTOs.AdminDto;

public class GetAdminDto: GetUserDto
{
    public int? SchoolId { get; set; }

    [JsonIgnore]
    public string? VerificationToken { get; set; }
    public bool IsVerified { get; set; }
}