using System.ComponentModel.DataAnnotations;

namespace eDnevnik___backend.DTOs.ExamDto;

public class GetExamDto
{
    public int Id { get; set; }
    public string ExamName { get; set; } = null!;
    [DataType(DataType.Date)]
    public DateTime ExamDate { get; set; }
    public string PostContent { get; set; } = null!;
    public int TeacherId { get; set; }
    public int SubjectId { get; set; }
    public string? Subject { get; set; }
    public int DepartmentId { get; set; }
}