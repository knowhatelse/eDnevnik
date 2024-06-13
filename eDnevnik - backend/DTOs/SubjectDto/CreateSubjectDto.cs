namespace eDnevnik___backend.DTOs.SubjectDto
{
    public class CreateSubjectDto
    {
        public string SubjectName { get; set; } = null!;
        public int TeacherId { get; set; }
        public int SchoolId { get; set; }
    }
}
