using eDnevnik___backend.Data;
using eDnevnik___backend.DTOs.AdminDto;
using eDnevnik___backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik___backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminController(IAdminService adminService, eDnevnikDbContext context) 
        : BaseUserController<GetAdminDto, CreateAdminDto, UpdateAdminDto>(adminService, context)
    {
    }
}
