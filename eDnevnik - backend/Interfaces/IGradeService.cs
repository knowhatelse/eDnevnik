using eDnevnik___backend.DTOs.GradeDto;

namespace eDnevnik___backend.Interfaces
{
    public interface IGradeService : IBaseCRUDService<GetGradeDto, CreateGradeDto, UpdateGradeDto>
    {
        public List<GetGradeDto>? GetStudentGrades(int studentId);
        public List<GetGradeDto>? GetTeacherGrades(int teacherId);
    }
}
