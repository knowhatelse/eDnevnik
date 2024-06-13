using eDnevnik___backend.DTOs.UserDto;

namespace eDnevnik___backend.DTOs.TeacherDto
{
    public class UpdateTeacherDto: UpdateUserDto
    {
        public bool IsClassTeacher { get; set; }
    }
}
