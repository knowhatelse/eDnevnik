using System.ComponentModel.DataAnnotations;

namespace eDnevnik___backend.DTOs.ParentJustificationDto;

public class GetParentJustificationDto
{
    public int Id { get; set; }
    public string JustificationReason { get; set; } = null!;
    [DataType(DataType.Date)]
    public DateTime JustificationDate { get; set; }
    public int ParentId { get; set; }
    public int AbsenceId { get; set; }
}