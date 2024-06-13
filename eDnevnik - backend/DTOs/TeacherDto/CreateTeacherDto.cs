using eDnevnik___backend.DTOs.UserDto;

namespace eDnevnik___backend.DTOs.TeacherDto
{
    public class CreateTeacherDto: CreateUserDto
    {
        public bool IsClassTeacher { get; set; }
    }
}
