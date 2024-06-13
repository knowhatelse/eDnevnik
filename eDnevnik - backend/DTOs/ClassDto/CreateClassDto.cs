namespace eDnevnik___backend.DTOs.ClassDto
{
    public class CreateClassDto
    {
        public int ClassNumber { get; set; }
        public string ClassName { get; set; } = null!;
        public int SchoolId { get; set; }
    }
}
