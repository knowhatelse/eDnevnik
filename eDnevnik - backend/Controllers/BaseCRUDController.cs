using eDnevnik___backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik___backend.Controllers;

[Route("api/[controller]")]
[Authorize]
public class BaseCRUDController<TGetDto, TCreateDto, TUpdateDto>(IBaseCRUDService<TGetDto, TCreateDto, TUpdateDto> baseCRUDService) : ControllerBase
{
    private readonly IBaseCRUDService<TGetDto, TCreateDto, TUpdateDto> _baseCRUDService = baseCRUDService;

    [HttpGet("GetAll/{schoolId:int}")]
    public ActionResult<ICollection<TGetDto>> GetAllRecords(int schoolId)
    {
        var response = _baseCRUDService.GetAll(schoolId);

        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }

    [HttpGet("GetById/{id:int}")]
    public ActionResult<TGetDto> GetRecordById(int id)
    {
        var response = _baseCRUDService.GetById(id);

        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }

    [HttpPost("Add")]
    public ActionResult<TGetDto> AddRecord(TCreateDto record)
    {
        var response = _baseCRUDService.Add(record);
        return Ok(response);
    }

    [HttpPut("Update/{id:int}")]
    public ActionResult<TGetDto> UpdateRecord(int id, TUpdateDto record)
    {
        var response = _baseCRUDService.Update(id, record);

        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }

    [HttpDelete("Delete/{id:int}")]
    public ActionResult<bool> DeleteRecord(int id)
    {
        if (!_baseCRUDService.Delete(id))
        {
            return NotFound();
        }

        return Ok("The record has been deleted!");
    }
    
}