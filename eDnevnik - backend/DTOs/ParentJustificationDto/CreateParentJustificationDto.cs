using System.ComponentModel.DataAnnotations;

namespace eDnevnik___backend.DTOs.ParentJustificationDto;

public class CreateParentJustificationDto
{
    public string JustificationReason { get; set; } = null!;
    [DataType(DataType.Date)]
    public DateTime JustificationDate { get; set; }
    public int ParentId { get; set; }
    public int AbsenceId { get; set; }
    public int SchoolId { get; set; }
}