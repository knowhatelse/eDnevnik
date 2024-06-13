using eDnevnik___backend.DTOs.ContactInformationDto;
using eDnevnik___backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik___backend.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ContactInformationController(IContactInformationService contactInformationService)
    : BaseCRUDController<GetContactInformationDto, CreateContactInformationDto, UpdateContactInformationDto>(contactInformationService) 
{
}