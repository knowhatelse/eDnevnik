using eDnevnik___backend.DTOs.DepartmentDto;

namespace eDnevnik___backend.Interfaces;

public interface IDepartmentService
    : IBaseCRUDService<GetDepartmentDto, CreateDepartmentDto, UpdateDepartmentDto>
{
    public List<GetDepartmentDto>? GetDepartmentsByClass(int classId);
}