using eDnevnik___backend.Data;
using eDnevnik___backend.DTOs.ParentDto;
using eDnevnik___backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik___backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ParentController(IParentService parentService, eDnevnikDbContext context) 
        : BaseUserController<GetParentDto, CreateParentDto, UpdateParentDto>(parentService, context)
    {
    }
}
