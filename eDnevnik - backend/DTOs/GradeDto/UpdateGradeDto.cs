using System.ComponentModel.DataAnnotations;

namespace eDnevnik___backend.DTOs.GradeDto
{
    public class UpdateGradeDto
    {
        public int GradeValue { get; set; }
        public string GradeNote { get; set; } = null!;
        [DataType(DataType.Date)]
        public DateTime DateOfAssessment { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
    }
}
