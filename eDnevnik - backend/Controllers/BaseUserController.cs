using eDnevnik___backend.Data;
using eDnevnik___backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik___backend.Controllers;

[Route("api/[controller]")]
[Authorize]
public class BaseUserController<TGetDto, TCreateDto, TUpdateDto>(IBaseUserService<TGetDto, TCreateDto, TUpdateDto> baseUserService, eDnevnikDbContext context)
    : BaseCRUDController<TGetDto, TCreateDto, TUpdateDto>(baseUserService)
{
    private readonly eDnevnikDbContext _context = context;
}