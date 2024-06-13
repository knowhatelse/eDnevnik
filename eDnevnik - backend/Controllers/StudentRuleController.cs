using eDnevnik___backend.DTOs.StudentRuleDto;
using eDnevnik___backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik___backend.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class StudentRuleController(IStudentRuleService studentRuleService) 
    : BaseCRUDController<GetStudentRuleDto, CreateStudentRuleDto, UpdateStudentRuleDto>(studentRuleService)
{
    private readonly IStudentRuleService _studentRuleService = studentRuleService;

    [HttpGet("GetStudentRuleByStudent/{studentId:int}")]
    public ActionResult<ICollection<GetStudentRuleDto>> GetStudentRuleByStudent(int studentId)
    {
        var response = _studentRuleService.GetStudentRuleByStudent(studentId);

        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }
}