using AutoMapper;
using eDnevnik___backend.Data;
using eDnevnik___backend.DTOs.ParentMeetingDto;
using eDnevnik___backend.Entities;
using eDnevnik___backend.Interfaces;

namespace eDnevnik___backend.Services;

public class ParentMeetingService(eDnevnikDbContext context, IMapper mapper)
    : BaseCRUDService<ParentMeeting, GetParentMeetingDto, CreateParentMeetingDto, UpdateParentMeetingDto>(context, mapper),
    IParentMeetingService
{
    private readonly eDnevnikDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public override List<GetParentMeetingDto>? GetAll(int schoolId)
    {
        var records = _context.ParentMeetings.ToList();
        return records.Count == 0 ? null : _mapper.Map<List<GetParentMeetingDto>>(records);
    }
}