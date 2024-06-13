namespace eDnevnik___backend.DTOs.MeetingConfirmationDto;

public class GetMeetingConfirmationDto
{
    public int Id { get; set; }
    public bool AttendanceConfirmed { get; set; }
    public int ParentMeetingId { get; set; }
    public int ParentId { get; set; }
}