using System.ComponentModel.DataAnnotations;

namespace eDnevnik___backend.DTOs.ParentMeetingDto;

public class CreateParentMeetingDto
{
    [DataType(DataType.Date)]
    public DateTime MeetingDate { get; set; }
    public string PostContent { get; set; } = null!;
    public int DepartmentId { get; set; }
    public int SchoolId { get; set; }
}