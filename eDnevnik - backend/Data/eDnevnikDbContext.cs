using eDnevnik___backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace eDnevnik___backend.Data
{
    public class eDnevnikDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Absence> Absences { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassSubject> ClassSubjects { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<MeetingConfirmation> MeetingConfirmations { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<ParentJustification> ParentJustifications { get; set; }
        public DbSet<ParentMeeting> ParentMeetings { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentRule> StudentRules { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; } 
    }
}
