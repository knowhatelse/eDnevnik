namespace eDnevnik___backend.DTOs.ReportDto;

public class GetReportDto
{
    public int Id { get; set; }
    public float FinalGrade { get; set; }
    public int StudentId { get; set; }
    public int TeacherId { get; set; }
    public int? StudentRuleId { get; set; }
}