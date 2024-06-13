using eDnevnik___backend.DTOs.UserDto;

namespace eDnevnik___backend.DTOs.StudentDto
{
    public class GetStudentDto: GetUserDto
    {
        public int ParentId { get; set; }
        public int DepartmentId { get; set; }
    }
}
