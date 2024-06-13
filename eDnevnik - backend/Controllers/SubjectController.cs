using eDnevnik___backend.DTOs.SubjectDto;
using eDnevnik___backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik___backend.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class SubjectController(ISubjectService subjectService) 
    : BaseCRUDController<GetSubjectDto, CreateSubjectDto, UpdateSubjectDto>(subjectService)
{
}