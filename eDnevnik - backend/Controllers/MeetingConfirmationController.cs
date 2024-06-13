using eDnevnik___backend.DTOs.MeetingConfirmationDto;
using eDnevnik___backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik___backend.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class MeetingConfirmationController(IMeetingConfirmationService meetingConfirmationService)
    : BaseCRUDController<GetMeetingConfirmationDto, CreateMeetingConfirmationDto, UpdateMeetingConfirmationDto>(meetingConfirmationService)
{
}