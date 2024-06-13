using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eDnevnik___backend.Entities;

public class Note
{
    [Key]
    public int Id { get; set; }
    public string NoteContent { get; set; } = null!;
    [DataType(DataType.Date)]
    public DateTime NoteDate { get; set; }
    public int ShoolId { get; set; }
    
    [ForeignKey("Student")]
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;
    
    [ForeignKey("Teacher")]
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; } = null!;
}