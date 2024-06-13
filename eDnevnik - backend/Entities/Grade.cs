using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eDnevnik___backend.Entities
{
    public class Grade
    {
        [Key]
        public int Id { get; set; }
        public int GradeValue { get; set; }
        public string GradeNote { get; set; } = null!;
        [DataType(DataType.Date)]
        public DateTime DateOfAssessment { get; set; }
        public int? FinalGrade { get; set; }
        public int ShoolId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; } = null!;
    }
}
