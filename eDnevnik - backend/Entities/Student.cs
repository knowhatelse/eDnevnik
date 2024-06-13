using System.ComponentModel.DataAnnotations.Schema;

namespace eDnevnik___backend.Entities
{
    public class Student : User
    {
        [ForeignKey("Parent")] 
        public int ParentId { get; set; }
        public Parent Parent { get; set; } = null!;

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;

        public Report? Report { get; set; }
        public StudentRule? StudentRule { get; set; }

        public ICollection<Absence> Absences { get; set; } = new List<Absence>();        
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();        
        public ICollection<Note> Notes { get; set; } = new List<Note>();
    }
}
