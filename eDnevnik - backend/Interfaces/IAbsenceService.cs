using eDnevnik___backend.DTOs.AbsenceDto;

namespace eDnevnik___backend.Interfaces;

public interface IAbsenceService: IBaseCRUDService<GetAbsenceDto, CreateAbsenceDto, UpdateAbsenceDto>
{
    public List<GetAbsenceDto>? GetAbsencesByStudent(int studentId);
}