using System.ComponentModel.DataAnnotations;

namespace eDnevnik___backend.DTOs.ExamDto;

public class CreateExamDto
{
    public string ExamName { get; set; } = null!;
    [DataType(DataType.Date)]
    public DateTime ExamDate { get; set; }
    public string PostContent { get; set; } = null!;
    public int TeacherId { get; set; }
    public int SubjectId { get; set; }
    public int DepartmentId { get; set; }
    public int SchoolId { get; set; }
    
}