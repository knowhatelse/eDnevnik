using eDnevnik___backend.DTOs.ParentJustificationDto;
using eDnevnik___backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik___backend.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ParentJustificationController(IParentJustificationService parentJustificationService)
    : BaseCRUDController<GetParentJustificationDto, CreateParentJustificationDto, UpdateParentJustificationDto>(parentJustificationService)
{
}