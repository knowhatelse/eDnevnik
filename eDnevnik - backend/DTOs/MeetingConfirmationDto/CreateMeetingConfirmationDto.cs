namespace eDnevnik___backend.DTOs.MeetingConfirmationDto;

public class CreateMeetingConfirmationDto
{
    public bool AttendanceConfirmed { get; set; }
    public int ParentMeetingId { get; set; }
    public int ParentId { get; set; }
    public int SchoolId { get; set; }
}