namespace eDnevnik___backend.DTOs.SubjectDto
{
    public class UpdateSubjectDto
    {
        public string SubjectName { get; set; } = null!;
        public int TeacherId { get; set; }
    }
}
