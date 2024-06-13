using System.ComponentModel.DataAnnotations;
using eDnevnik___backend.Entities;

namespace eDnevnik___backend.DTOs.AbsenceDto;

public class GetAbsenceDto
{
    public int Id { get; set; }  
    public string Lecture { get; set; } = null!;
    [DataType(DataType.Date)]
    public DateTime AbsenceDate { get; set; }
    public string AbsenceNote { get; set; } = null!;
    public bool? Justified { get; set; }
    public int StudentId { get; set; }
    public int TeacherId { get; set; }
    public string? Teacher { get; set; }

}