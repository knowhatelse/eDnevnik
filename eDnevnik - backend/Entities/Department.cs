using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eDnevnik___backend.Entities;

public class Department
{ 
    [Key] 
    public int Id { get; set; }
    public string DepartmentNumber { get; set; } = null!;
    public string DepartmentName { get; set; } = null!;
    public int ShoolId { get; set; }

    [ForeignKey("Class")]
    public int ClassId { get; set; }
    public Class Class { get; set; } = null!;

    [ForeignKey("Teacher")]
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; } = null!;

    public ICollection<Student> Students { get; } = new List<Student>();
    public ICollection<ParentMeeting> ParentMeetings { get; } = new List<ParentMeeting>();
    public ICollection<Exam> Exams { get; set; } = new List<Exam>();
}