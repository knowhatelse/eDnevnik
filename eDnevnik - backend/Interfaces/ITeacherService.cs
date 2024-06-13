using eDnevnik___backend.DTOs.TeacherDto;
using eDnevnik___backend.DTOs.UserDto;

namespace eDnevnik___backend.Interfaces;

public interface ITeacherService : IBaseUserService<GetTeacherDto, CreateTeacherDto, UpdateTeacherDto>
{
    public GetTeacherDto? GetClassTeacher(int departmentId);
}