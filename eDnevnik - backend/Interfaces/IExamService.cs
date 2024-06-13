using eDnevnik___backend.DTOs.ExamDto;

namespace eDnevnik___backend.Interfaces;

public interface IExamService : IBaseCRUDService<GetExamDto, CreateExamDto, UpdateExamDto>
{
    public List<GetExamDto>? GetExamsByDepartment(int departmentId);
}