using AutoMapper;
using eDnevnik___backend.Data;
using eDnevnik___backend.DTOs.StudentRuleDto;
using eDnevnik___backend.Entities;
using eDnevnik___backend.Interfaces;

namespace eDnevnik___backend.Services;

public class StudentRuleService(eDnevnikDbContext context, IMapper mapper)
    : BaseCRUDService<StudentRule, GetStudentRuleDto, CreateStudentRuleDto, UpdateStudentRuleDto>(context, mapper), IStudentRuleService
{
    private readonly eDnevnikDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public List<GetStudentRuleDto>? GetStudentRuleByStudent(int studentId)
    {
        var studentRules = _context.StudentRules.Where(sr => sr.StudentId == studentId).ToList();
        return studentRules.Count == 0 ? null : _mapper.Map<List<GetStudentRuleDto>>(studentRules);
    }

    public override List<GetStudentRuleDto>? GetAll(int schoolId)
    {
        var records = _context.StudentRules.ToList();
        return records.Count == 0 ? null : _mapper.Map<List<GetStudentRuleDto>>(records);
    }
}