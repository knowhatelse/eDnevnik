using eDnevnik___backend.Entities;

namespace eDnevnik___backend.DTOs.ClassDto
{
    public class GetClassDto
    {
        public int Id { get; set; }
        public int ClassNumber { get; set; }
        public string ClassName { get; set; } = null!;
    }
}
