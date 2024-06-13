namespace eDnevnik___backend.DTOs.ReportDto;

public class CreateReportDto
{
    public float FinalGrade { get; set; }
    public int StudentId { get; set; }
    public int TeacherId { get; set; }
    public int? StudentRuleId { get; set; }
    public int SchoolId { get; set; }
    
}