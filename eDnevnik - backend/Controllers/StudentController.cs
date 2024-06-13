using eDnevnik___backend.Data;
using eDnevnik___backend.DTOs.StudentDto;
using eDnevnik___backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik___backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController(IStudentService studentService, eDnevnikDbContext context) 
        : BaseUserController<GetStudentDto, CreateStudentDto, UpdateStudentDto>(studentService, context)
    {
        private readonly IStudentService _studentService = studentService;

        [HttpGet("GetAllStudentsByClass/{classId:int}")]
        public ActionResult<List<GetStudentDto>> GetAllStudentsByClass(int classId)
        {
            var response = _studentService.GetAllStudentsByClass(classId);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet("GetAllStudentsByDepartment/{departmentId:int}")]
        public ActionResult<List<GetStudentDto>> GetAllStudentsByDepartment(int departmentId)
        {
            var response = _studentService.GetAllStudentsByDepartment(departmentId);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
