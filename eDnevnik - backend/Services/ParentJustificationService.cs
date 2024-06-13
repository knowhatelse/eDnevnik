using AutoMapper;
using eDnevnik___backend.Data;
using eDnevnik___backend.DTOs.ParentJustificationDto;
using eDnevnik___backend.Entities;
using eDnevnik___backend.Interfaces;

namespace eDnevnik___backend.Services;

public class ParentJustificationService(eDnevnikDbContext context, IMapper mapper)
    : BaseCRUDService<ParentJustification, GetParentJustificationDto, CreateParentJustificationDto, UpdateParentJustificationDto>(context, mapper),
    IParentJustificationService
{
    private readonly eDnevnikDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public override List<GetParentJustificationDto>? GetAll(int schoolId)
    {
        var records = _context.ParentJustifications.ToList();
        return records.Count == 0 ? null : _mapper.Map<List<GetParentJustificationDto>>(records);
    }
}