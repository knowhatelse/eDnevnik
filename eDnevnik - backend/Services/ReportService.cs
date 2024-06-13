using AutoMapper;
using eDnevnik___backend.Data;
using eDnevnik___backend.DTOs.ReportDto;
using eDnevnik___backend.Entities;
using eDnevnik___backend.Interfaces;

namespace eDnevnik___backend.Services;

public class ReportService(eDnevnikDbContext context, IMapper mapper)
    : BaseCRUDService<Report, GetReportDto, CreateReportDto, UpdateReportDto>(context, mapper), IReportService
{
    private readonly eDnevnikDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public override List<GetReportDto>? GetAll(int schoolId)
    {
        var records = _context.Reports.ToList();
        return records.Count == 0 ? null : _mapper.Map<List<GetReportDto>>(records);
    }
}