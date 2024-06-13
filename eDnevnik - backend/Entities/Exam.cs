using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace eDnevnik___backend.Entities;

public class Exam 
{
    [Key]
    public int Id { get; set; }
    public string ExamName { get; set; } = null!;
    [DataType(DataType.Date)]
    public DateTime ExamDate { get; set; }
    public string PostContent { get; set; } = null!;
    public int ShoolId { get; set; }
    
    [ForeignKey("Teacher")]
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; } = null!;
    
    [ForeignKey("Subject")]
    public int SubjectId { get; set; }
    public Subject Subject { get; set; } = null!;
    
    [ForeignKey("Department")]
    public int DepartmentId { get; set; }
    public Department Department { get; set; } = null!;
}