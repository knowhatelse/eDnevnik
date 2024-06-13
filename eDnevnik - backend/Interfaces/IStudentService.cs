using eDnevnik___backend.DTOs.SchoolDto;
using eDnevnik___backend.DTOs.StudentDto;
using eDnevnik___backend.DTOs.UserDto;

namespace eDnevnik___backend.Interfaces;

public interface IStudentService : IBaseUserService<GetStudentDto, CreateStudentDto, UpdateStudentDto>
{
    public List<GetStudentDto>? GetAllStudentsByClass(int classId);
    public List<GetStudentDto>? GetAllStudentsByDepartment(int departmentId);
}