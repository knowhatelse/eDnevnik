using eDnevnik___backend.DTOs.StudentRuleDto;

namespace eDnevnik___backend.Interfaces;

public interface IStudentRuleService 
    : IBaseCRUDService<GetStudentRuleDto, CreateStudentRuleDto, UpdateStudentRuleDto>
{
    List<GetStudentRuleDto>? GetStudentRuleByStudent(int studentId);
}