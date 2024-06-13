using eDnevnik___backend.DTOs.GradeDto;
using eDnevnik___backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik___backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GradeController(IGradeService gradeService) : BaseCRUDController<GetGradeDto, CreateGradeDto, UpdateGradeDto>(gradeService)
    {
        private IGradeService _gradeService = gradeService;

        [HttpGet("GetStudentGrades/{studentId:int}")]
        public ActionResult<List<GetGradeDto>> GetStudentGrades(int studentId)
        {
            var response = _gradeService.GetStudentGrades(studentId);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
        
        [HttpGet("GetTeacherGrades/{teacherId:int}")]
        public ActionResult<List<GetGradeDto>> GetTeacherGrades(int teacherId)
        {
            var response = _gradeService.GetTeacherGrades(teacherId);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
