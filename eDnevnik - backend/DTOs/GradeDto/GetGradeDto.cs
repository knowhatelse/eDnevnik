using System.ComponentModel.DataAnnotations;
using eDnevnik___backend.Entities;

namespace eDnevnik___backend.DTOs.GradeDto
{
    public class GetGradeDto
    {
        public int Id { get; set; }
        public int GradeValue { get; set; }
        public string GradeNote { get; set; } = null!;
        [DataType(DataType.Date)]
        public DateTime DateOfAssessment { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public string? Subject { get; set; }
    }
}
