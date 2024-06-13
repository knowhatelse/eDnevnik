using AutoMapper;
using eDnevnik___backend.Data;
using eDnevnik___backend.DTOs.MeetingConfirmationDto;
using eDnevnik___backend.Entities;
using eDnevnik___backend.Interfaces;

namespace eDnevnik___backend.Services;

public class MeetingConfirmationService(eDnevnikDbContext context, IMapper mapper)
    : BaseCRUDService<MeetingConfirmation, GetMeetingConfirmationDto, CreateMeetingConfirmationDto, UpdateMeetingConfirmationDto>(context, mapper),
    IMeetingConfirmationService
{
    private readonly eDnevnikDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public override List<GetMeetingConfirmationDto>? GetAll(int schoolId)
    {
        var records = _context.MeetingConfirmations.ToList();
        return records.Count == 0 ? null : _mapper.Map<List<GetMeetingConfirmationDto>>(records);
    }
}