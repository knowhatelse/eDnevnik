using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eDnevnik___backend.Entities;

public class ParentMeeting
{
    [Key] 
    public int Id { get; set; }
    [DataType(DataType.Date)]
    public DateTime MeetingDate { get; set; }
    public string PostContent { get; set; } = null!;
    public int ShoolId { get; set; }

    [ForeignKey("Department")]
    public int DepartmentId { get; set; }
    public Department Department { get; set; } = null!;

    public ICollection<MeetingConfirmation> MeetingConfirmations { get; } = new List<MeetingConfirmation>();
}