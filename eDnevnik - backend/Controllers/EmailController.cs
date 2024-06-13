using eDnevnik___backend.DTOs.EmailDto;
using eDnevnik___backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik___backend.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class EmailController(IEmailService emailService) : BaseCRUDController<GetEmailDto, CreateEmailDto, UpdateEmailDto>(emailService)
{
}