namespace eDnevnik___backend.DTOs.MeetingConfirmationDto;

public class UpdateMeetingConfirmationDto
{
    public bool AttendanceConfirmed { get; set; }
    public int ParentMeetingId { get; set; }
    public int ParentId { get; set; }
}