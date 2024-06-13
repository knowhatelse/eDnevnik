namespace eDnevnik___backend.DTOs.UserDto;

public class GetUserPasswordDto
{
    public string Salt { get; set; } = null!;
    public string Hash { get; set; } = null!;
}