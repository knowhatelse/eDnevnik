namespace eDnevnik___backend.DTOs.DepartmentDto;

public class CreateDepartmentDto
{
    public string DepartmentNumber { get; set; } = null!;
    public string DepartmentName { get; set; } = null!;
    public int ClassId { get; set; }
    public int TeacherId { get; set; }
    public int SchoolId { get; set; }
}