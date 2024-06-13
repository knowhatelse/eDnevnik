namespace eDnevnik___backend.DTOs.EmailDto;

public class CreateEmailDto
{
    public string Subject { get; set; } = null!;
    public string Content { get; set; } = null!;
    public int UserId { get; set; }
}