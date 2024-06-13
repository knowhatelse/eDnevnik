using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eDnevnik___backend.Entities;

public class ClassSubject
{
    [Key]
    public int Id { get; set; }
    public int ShoolId { get; set; }
    
    [ForeignKey("Class")]
    public int ClassId { get; set; }
    public Class Class { get; set; } = null!;

    [ForeignKey("Subject")]
    public int SubjectId { get; set; }
    public Subject Subject { get; set; } = null!;
}