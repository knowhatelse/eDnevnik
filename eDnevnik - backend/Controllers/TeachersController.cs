using eDnevnik___backend.Data;
using eDnevnik___backend.DTOs.TeacherDto;
using eDnevnik___backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik___backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TeachersController(ITeacherService teacherService, eDnevnikDbContext context)
        : BaseUserController<GetTeacherDto, CreateTeacherDto, UpdateTeacherDto>(teacherService, context)
    {
        private readonly ITeacherService _teacherService = teacherService;

        [HttpGet("GetClassTeacher/{departmentId:int}")]
        public ActionResult<GetTeacherDto> GetClassTeacher(int departmentId)
        {
            var response = _teacherService.GetClassTeacher(departmentId);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
        
    }

}
