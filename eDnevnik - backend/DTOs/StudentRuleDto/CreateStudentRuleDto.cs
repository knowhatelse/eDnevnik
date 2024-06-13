using System.ComponentModel.DataAnnotations;

namespace eDnevnik___backend.DTOs.StudentRuleDto;

public class CreateStudentRuleDto
{
    public int RuleValue { get; set; }
    public string RuleReason { get; set; } = null!;
    [DataType(DataType.Date)]
    public DateTime RuleDate { get; set; }
    public int StudentId { get; set; }
    public int SchoolId { get; set; }
}