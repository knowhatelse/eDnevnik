using eDnevnik___backend.Data;
using eDnevnik___backend.DTOs.UserDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik___backend.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController(IUserService userService, eDnevnikDbContext context)
    : BaseUserController<GetUserDto, CreateUserDto, UpdateUserDto>(userService, context)
{
}