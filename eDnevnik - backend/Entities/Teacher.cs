using System.ComponentModel.DataAnnotations.Schema;

namespace eDnevnik___backend.Entities
{
    public class Teacher : User
    {
        public bool IsClassTeacher { get; set; }
        
        public Department? Department { get; set; }
        
        public ICollection<Absence> Absences { get; set; } = new List<Absence>();
        public ICollection<Exam> Exams { get; set; } = new List<Exam>();
        public ICollection<Note> Notes { get; set; } = new List<Note>();
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
        public ICollection<Report> Reports { get; set; } = new List<Report>();
    }
}
