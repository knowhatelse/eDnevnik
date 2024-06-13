using AutoMapper;
using eDnevnik___backend.Data;
using eDnevnik___backend.DTOs.StudentDto;
using eDnevnik___backend.Entities;
using eDnevnik___backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eDnevnik___backend.Services
{
    public class StudentService(eDnevnikDbContext context, IMapper mapper) 
        : BaseUserService<Student, GetStudentDto, CreateStudentDto, UpdateStudentDto>(context, mapper), IStudentService
    {
        private readonly eDnevnikDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public List<GetStudentDto>? GetAllStudentsByClass(int classId)
        {
            var students = _context.Students
                .Include(s => s.Department).Where(s => s.Department.ClassId == classId)
                .ToList();

            return students.Count == 0 ? null : _mapper.Map<List<GetStudentDto>>(students);
        }

        public List<GetStudentDto>? GetAllStudentsByDepartment(int departmentId)
        {
            var students = _context.Students
                .Include(s => s.Department).Where(s => s.DepartmentId == departmentId)
                .ToList();

            return students.Count == 0 ? null : _mapper.Map<List<GetStudentDto>>(students);
        }
    }
}
