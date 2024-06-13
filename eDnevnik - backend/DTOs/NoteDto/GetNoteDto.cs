using System.ComponentModel.DataAnnotations;

namespace eDnevnik___backend.DTOs.NoteDto;

public class GetNoteDto
{
    public int Id { get; set; }
    public string NoteContent { get; set; } = null!;
    [DataType(DataType.Date)]
    public DateTime NoteDate { get; set; }
    public int StudentId { get; set; }
    public int TeacherId { get; set; }
    public string? Teacher { get; set; }
}