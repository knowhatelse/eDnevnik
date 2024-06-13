using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace eDnevnik___backend.DTOs.UserDto
{
    public class UpdateUserDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public bool Enabled2FA { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [JsonIgnore]
        public string? Token2FA { get; set; }
    }
}
