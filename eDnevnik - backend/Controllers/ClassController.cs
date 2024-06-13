using eDnevnik___backend.DTOs.ClassDto;
using eDnevnik___backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik___backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClassController(IClassService classService) : BaseCRUDController<GetClassDto, CreateClassDto, UpdateClassDto>(classService)
    {
    }
}
