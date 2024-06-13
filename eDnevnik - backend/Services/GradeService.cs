using eDnevnik___backend.Data;
using eDnevnik___backend.DTOs.GradeDto;
using eDnevnik___backend.Entities;
using eDnevnik___backend.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace eDnevnik___backend.Services
{
    public class GradeService(eDnevnikDbContext context, IMapper mapper)
        : BaseCRUDService<Grade, GetGradeDto, CreateGradeDto, UpdateGradeDto>(context, mapper), IGradeService
    {
        private readonly eDnevnikDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public List<GetGradeDto>? GetStudentGrades(int studentId)
        {
            var studentGrades = _context.Grades.Include(g => g.Subject).Where(g => g.StudentId == studentId).ToList();
            return studentGrades.Count == 0 ? null : _mapper.Map<List<GetGradeDto>>(studentGrades);
        }

        public List<GetGradeDto>? GetTeacherGrades(int teacherId)
        {
            var teacherGrades = _context.Grades
                .Include(g=> g.Subject)
                .Where(g => g.Subject.TeacherId == teacherId).ToList();
            
            return teacherGrades.Count == 0 ? null : _mapper.Map<List<GetGradeDto>>(teacherGrades);
        }

        public override List<GetGradeDto>? GetAll(int schoolId)
        {
            var records = _context.Grades.ToList();
            return records.Count == 0 ? null : _mapper.Map<List<GetGradeDto>>(records);
        }
    }
}   
