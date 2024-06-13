using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eDnevnik___backend.Entities
{
    public class Class
    {
        [Key]
        public int Id { get; set; }
        public int ClassNumber { get; set; }
        public string ClassName { get; set; } = null!;

        [ForeignKey("School")]
        public int SchoolId { get; set; }
        public School School { get; set; } = null!;

        public ICollection<Department> Departments { get; } = new List<Department>();
        public ICollection<ClassSubject> ClassSubjects { get; set; } = new List<ClassSubject>();
    }
}
