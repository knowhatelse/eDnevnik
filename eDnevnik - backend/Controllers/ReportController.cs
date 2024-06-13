using eDnevnik___backend.DTOs.ReportDto;
using eDnevnik___backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik___backend.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ReportController(IReportService reportService) : BaseCRUDController<GetReportDto, CreateReportDto, UpdateReportDto>(reportService)
{
}