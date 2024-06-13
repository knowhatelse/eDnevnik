using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eDnevnik___backend.Entities;

public class MeetingConfirmation
{
    [Key] 
    public int Id { get; set; }
    public bool AttendanceConfirmed { get; set; }
    public int ShoolId { get; set; }

    [ForeignKey("ParentMeeting")]
    public int ParentMeetingId { get; set; }
    public ParentMeeting ParentMeeting { get; set; } = null!;

    [ForeignKey("Parent")]
    public int ParentId { get; set; }
    public Parent Parent { get; set; } = null!;
}