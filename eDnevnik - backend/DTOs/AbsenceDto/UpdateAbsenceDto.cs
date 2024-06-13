using System.ComponentModel.DataAnnotations;

namespace eDnevnik___backend.DTOs.AbsenceDto;

public class UpdateAbsenceDto
{
    public string Lecture { get; set; } = null!;
    [DataType(DataType.Date)]
    public DateTime AbsenceDate { get; set; }
    public string AbsenceNote { get; set; } = null!;
    public bool? Justified { get; set; }
    public int StudentId { get; set; }
    public int TeacherId { get; set; }
}