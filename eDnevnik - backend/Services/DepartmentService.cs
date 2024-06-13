using AutoMapper;
using eDnevnik___backend.Data;
using eDnevnik___backend.DTOs.DepartmentDto;
using eDnevnik___backend.Entities;
using eDnevnik___backend.Interfaces;

namespace eDnevnik___backend.Services;

public class DepartmentService(eDnevnikDbContext context, IMapper mapper)
    : BaseCRUDService<Department, GetDepartmentDto, CreateDepartmentDto, UpdateDepartmentDto>(context, mapper), IDepartmentService
{
    private readonly eDnevnikDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public List<GetDepartmentDto>? GetDepartmentsByClass(int classId)
    {
        var departments = _context.Departments.Where(x => x.ClassId == classId).ToList();
        return departments.Count == 0 ? null : _mapper.Map<List<GetDepartmentDto>>(departments);
    }

    public override List<GetDepartmentDto>? GetAll(int schoolId)
    {
        var records = _context.Departments.ToList();
        return records.Count == 0 ? null : _mapper.Map<List<GetDepartmentDto>>(records);
    }

}