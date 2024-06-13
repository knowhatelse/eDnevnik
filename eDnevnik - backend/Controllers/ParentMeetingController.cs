using eDnevnik___backend.DTOs.ParentMeetingDto;
using eDnevnik___backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik___backend.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ParentMeetingController(IParentMeetingService parentMeetingService)
    : BaseCRUDController<GetParentMeetingDto, CreateParentMeetingDto, UpdateParentMeetingDto>(parentMeetingService)
{
}