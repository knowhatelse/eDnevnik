using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eDnevnik___backend.Entities
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        public string SubjectName { get; set; } = null!;
        public int ShoolId { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;

        public ICollection<Exam> Exams { get; set; } = new List<Exam>();
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
        public ICollection<ClassSubject> ClassSubjects { get; set; } = new List<ClassSubject>();
    }
}
