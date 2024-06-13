namespace eDnevnik___backend.DTOs.SubjectDto
{
    public class GetSubjectDto
    {
        public int Id { get; set; }
        public string SubjectName { get; set; } = null!;
        public int TeacherId { get; set; }
    }
}
