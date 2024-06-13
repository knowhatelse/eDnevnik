using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace eDnevnik___backend.DTOs.UserDto
{
    public class CreateUserDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [JsonIgnore]
        public bool? Enabled2FA { get; set; } = false;
        public int SchoolId { get; set; }
    }
}
