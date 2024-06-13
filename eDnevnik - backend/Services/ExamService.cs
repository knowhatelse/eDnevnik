using AutoMapper;
using eDnevnik___backend.Data;
using eDnevnik___backend.DTOs.ExamDto;
using eDnevnik___backend.Entities;
using eDnevnik___backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eDnevnik___backend.Services;

public class ExamService(eDnevnikDbContext context, IMapper mapper)
    : BaseCRUDService<Exam, GetExamDto, CreateExamDto, UpdateExamDto>(context, mapper), IExamService
{
    private readonly eDnevnikDbContext _context = context;
    private readonly IMapper _mapper = mapper;



    public List<GetExamDto>? GetExamsByDepartment(int departmentId)
    {
        var exams = _context.Exams.Include(e => e.Subject).Where(e => e.DepartmentId == departmentId).ToList();
        return exams.Count == 0 ? null : _mapper.Map<List<GetExamDto>>(exams);
    }

    public override List<GetExamDto>? GetAll(int schoolId)
    {
        var records = _context.Exams.ToList();
        return records.Count == 0 ? null : _mapper.Map<List<GetExamDto>>(records);
    }
}