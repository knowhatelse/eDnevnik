using eDnevnik___backend.DTOs.DepartmentDto;
using eDnevnik___backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik___backend.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class DepartmentController(IDepartmentService departmentService)
    : BaseCRUDController<GetDepartmentDto, CreateDepartmentDto, UpdateDepartmentDto>(departmentService)
{
    private readonly IDepartmentService _departmentService = departmentService;

    [HttpGet("GetDepartmentsByClass/{id}")]
    public ActionResult<ICollection<GetDepartmentDto>> GetDepartmentsByClass(int classId)
    {
        var response = _departmentService.GetDepartmentsByClass(classId);

        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }
}