using eDnevnik___backend.DTOs.SchoolDto;
using eDnevnik___backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik___backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SchoolController(ISchoolService schoolService) : BaseCRUDController<GetSchoolDto, CreateSchoolDto, UpdateSchoolDto>(schoolService)
    {
    }
}
