using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Routing.Constraints;

namespace eDnevnik___backend.Entities;

public class Report
{
    [Key]
    public int Id { get; set; }
    public float FinalGrade { get; set; }
    public int ShoolId { get; set; }

    [ForeignKey("Student")]
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;

    [ForeignKey("Teacher")]
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; } = null!;

    [ForeignKey("StudentRule")]
    public int? StudentRuleId { get; set; }
    public StudentRule? StudentRule { get; set; } = null!;
}