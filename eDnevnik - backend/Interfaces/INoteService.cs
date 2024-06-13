using eDnevnik___backend.DTOs.NoteDto;

namespace eDnevnik___backend.Interfaces;

public interface INoteService : IBaseCRUDService<GetNoteDto, CreateNoteDto, UpdateNoteDto>
{
    List<GetNoteDto>? GetNotesByStudent(int studentId);
}