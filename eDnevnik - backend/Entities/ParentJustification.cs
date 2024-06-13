using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eDnevnik___backend.Entities;

public class ParentJustification
{
    [Key]
    public int Id { get; set; }
    public string JustificationReason { get; set; } = null!;
    [DataType(DataType.Date)]
    public DateTime JustificationDate { get; set; }
    public int ShoolId { get; set; }
    
    [ForeignKey("Parent")]
    public int ParentId { get; set; }
    public Parent Parent { get; set; } = null!;
    
    [ForeignKey("Absence")]
    public int AbsenceId { get; set; }
    public Absence Absence { get; set; } = null!;
}