namespace eDnevnik___backend.Entities
{
    public class Parent: User
    {
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<MeetingConfirmation> MeetingConfirmations { get; set; } = new List<MeetingConfirmation>();
        public ICollection<ParentJustification> ParentJustifications { get; set; } = new List<ParentJustification>();
    }
}
