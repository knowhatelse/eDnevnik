using eDnevnik___backend.DTOs.ExamDto;
using eDnevnik___backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik___backend.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ExamController(IExamService examService) : BaseCRUDController<GetExamDto, CreateExamDto, UpdateExamDto>(examService)
{
    private readonly IExamService _examService = examService;

    [HttpGet("GetExamsByDepartment/{departmentId:int}")]
    public ActionResult<ICollection<GetExamDto>> GetDepartmentsByClass(int departmentId)
    {
        var response = _examService.GetExamsByDepartment(departmentId);

        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }
}