using AutoMapper;
using eDnevnik___backend.Data;
using eDnevnik___backend.DTOs.TeacherDto;
using eDnevnik___backend.Entities;
using eDnevnik___backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eDnevnik___backend.Services
{
    public class TeacherService(eDnevnikDbContext context, IMapper mapper) 
        : BaseUserService<Teacher, GetTeacherDto, CreateTeacherDto, UpdateTeacherDto>(context, mapper), ITeacherService
    {
        private readonly eDnevnikDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public GetTeacherDto? GetClassTeacher(int departmentId)
        {
            var classTeacher = _context.Teachers
                .Include(t => t.Department)
                .FirstOrDefault(t => t.Department!.Id == departmentId);

            return classTeacher == null ? null : _mapper.Map<GetTeacherDto>(classTeacher);
        }
    }
}

