using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eDnevnik___backend.Entities;

public class StudentRule
{
    [Key]
    public int Id { get; set; }
    public int RuleValue { get; set; }
    public string RuleReason { get; set; } = null!;
    [DataType(DataType.Date)]
    public DateTime RuleDate { get; set; }
    public int ShoolId { get; set; }
    
    [ForeignKey("Student")]
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;

    public Report? Report { get; set; }
}