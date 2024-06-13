using AutoMapper;
using eDnevnik___backend.Data;
using eDnevnik___backend.DTOs.AbsenceDto;
using eDnevnik___backend.Entities;
using eDnevnik___backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eDnevnik___backend.Services;

public class AbsenceService(eDnevnikDbContext context, IMapper mapper)
    : BaseCRUDService<Absence, GetAbsenceDto, CreateAbsenceDto, UpdateAbsenceDto>(context, mapper), IAbsenceService
{
    private readonly eDnevnikDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public List<GetAbsenceDto>? GetAbsencesByStudent(int studentId)
    {
        var absences = _context.Absences.Include(a => a.Teacher).Where(a => a.StudentId == studentId).ToList();
        return absences.Count == 0 ? null : _mapper.Map<List<GetAbsenceDto>>(absences);
    }

    public override List<GetAbsenceDto>? GetAll(int schoolId)
    {
          var records = _context.Absences.ToList();
        return records.Count == 0 ? null : _mapper.Map<List<GetAbsenceDto>>(records);
    }
}