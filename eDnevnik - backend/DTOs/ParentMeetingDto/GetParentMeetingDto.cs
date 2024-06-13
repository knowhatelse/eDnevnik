using System.ComponentModel.DataAnnotations;

namespace eDnevnik___backend.DTOs.ParentMeetingDto;

public class GetParentMeetingDto
{
    public int Id { get; set; }
    [DataType(DataType.Date)]
    public DateTime MeetingDate { get; set; }
    public string PostContent { get; set; } = null!;
    public int DepartmentId { get; set; }
}