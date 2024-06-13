using eDnevnik___backend.DTOs.AbsenceDto;
using eDnevnik___backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik___backend.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AbsenceController(IAbsenceService absenceService) 
    : BaseCRUDController<GetAbsenceDto, CreateAbsenceDto, UpdateAbsenceDto>(absenceService)
{
    private readonly IAbsenceService _absenceService = absenceService;

    [HttpGet("GetAbsencesByStudent/{studentId:int}")]
    public ActionResult<ICollection<GetAbsenceDto>> GetAbsencesByStudent(int studentId)
    {
        var response = _absenceService.GetAbsencesByStudent(studentId);

        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }
}