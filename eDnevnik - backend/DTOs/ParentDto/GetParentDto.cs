using eDnevnik___backend.DTOs.StudentDto;
using eDnevnik___backend.DTOs.UserDto;
using eDnevnik___backend.Entities;

namespace eDnevnik___backend.DTOs.ParentDto
{
    public class GetParentDto: GetUserDto
    {
        public ICollection<GetStudentDto>? Students { get; set; }
    }
}
