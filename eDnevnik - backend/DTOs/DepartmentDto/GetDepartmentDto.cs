namespace eDnevnik___backend.DTOs.DepartmentDto;

public class GetDepartmentDto
{
    public int Id { get; set; }
    public string DepartmentNumber { get; set; } = null!;
    public string DepartmentName { get; set; } = null!;
    public int ClassId { get; set; }
    public int TeacherId { get; set; }
}