using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eDnevnik___backend.Entities;

public class Absence
{
    [Key]
    public int Id { get; set; }
    public string Lecture { get; set; } = null!;
    [DataType(DataType.Date)]
    public DateTime AbsenceDate { get; set; }
    public string AbsenceNote { get; set; } = null!;
    public bool? Justified { get; set; }
    public int ShoolId { get; set; }
    
    [ForeignKey("Student")]
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;
    
    [ForeignKey("Teacher")]
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; } = null!;

    public ParentJustification? ParentJustification { get; set; }
}