using eDnevnik___backend.DTOs.UserDto;

namespace eDnevnik___backend.DTOs.TeacherDto
{
    public class GetTeacherDto: GetUserDto
    {
        public bool IsClassTeacher { get; set; }
    }
}
