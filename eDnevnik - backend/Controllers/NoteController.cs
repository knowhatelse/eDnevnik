using eDnevnik___backend.DTOs.NoteDto;
using eDnevnik___backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik___backend.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class NoteController(INoteService noteService) : BaseCRUDController<GetNoteDto, CreateNoteDto, UpdateNoteDto>(noteService)
{
    private readonly INoteService _noteService = noteService;

    [HttpGet("GetNotesByStudent/{studentId:int}")]
    public ActionResult<ICollection<GetNoteDto>> GetNotesByStudent(int studentId)
    {
        var response = _noteService.GetNotesByStudent(studentId);

        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }
}