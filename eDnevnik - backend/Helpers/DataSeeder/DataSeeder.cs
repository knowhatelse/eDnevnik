using AutoMapper;
using eDnevnik___backend.Data;
using eDnevnik___backend.DTOs.AbsenceDto;
using eDnevnik___backend.DTOs.AdminDto;
using eDnevnik___backend.DTOs.ClassDto;
using eDnevnik___backend.DTOs.ContactInformationDto;
using eDnevnik___backend.DTOs.DepartmentDto;
using eDnevnik___backend.DTOs.EmailDto;
using eDnevnik___backend.DTOs.ExamDto;
using eDnevnik___backend.DTOs.GradeDto;
using eDnevnik___backend.DTOs.MeetingConfirmationDto;
using eDnevnik___backend.DTOs.NoteDto;
using eDnevnik___backend.DTOs.ParentDto;
using eDnevnik___backend.DTOs.ParentJustificationDto;
using eDnevnik___backend.DTOs.ParentMeetingDto;
using eDnevnik___backend.DTOs.ReportDto;
using eDnevnik___backend.DTOs.SchoolDto;
using eDnevnik___backend.DTOs.StudentDto;
using eDnevnik___backend.DTOs.StudentRuleDto;
using eDnevnik___backend.DTOs.SubjectDto;
using eDnevnik___backend.DTOs.TeacherDto;
using eDnevnik___backend.Entities;
using eDnevnik___backend.Interfaces;
using eDnevnik___backend.Services;
using Microsoft.EntityFrameworkCore;

namespace eDnevnik___backend.Helpers;

public class DataSeeder(eDnevnikDbContext context, IMapper mapper) : IDataSeeder
{
    private readonly eDnevnikDbContext _context = context;

    private readonly IAdminService _adminService = new AdminService(context, mapper);
    private readonly ISchoolService _schoolService = new SchoolService(context, mapper);
    private readonly IParentService _parentService = new ParentService(context, mapper);
    private readonly IClassService _classService = new ClassService(context, mapper);
    private readonly ITeacherService _teacherService = new TeacherService(context, mapper);
    private readonly ISubjectService _subjectService = new SubjectService(context, mapper);
    private readonly IDepartmentService _departmentService = new DepartmentService(context, mapper);
    private readonly IStudentService _studentService = new StudentService(context, mapper);
    private readonly INoteService _noteService = new NoteService(context, mapper);
    private readonly IGradeService _gradeService = new GradeService(context, mapper);
    private readonly IStudentRuleService _studentRuleService = new StudentRuleService(context, mapper);
    private readonly IReportService _reportService = new ReportService(context, mapper);
    private readonly IParentMeetingService _parentMeetingService = new ParentMeetingService(context, mapper);
    private readonly IMeetingConfirmationService _meetingConfirmationService = new MeetingConfirmationService(context, mapper);
    private readonly IExamService _examService = new ExamService(context, mapper);
    private readonly IAbsenceService _absenceService = new AbsenceService(context, mapper);
    private readonly IParentJustificationService _parentJustificationService = new ParentJustificationService(context, mapper);
    private readonly IContactInformationService _contactInformationService = new ContactInformationService(context, mapper);
    private readonly IEmailService _emailService = new EmailService(context, mapper);

    private readonly Random _random = new();

    public bool SeedData()
    {
        var admin = SeedAdmins();
        var school = SeedSchool(admin);

        SeedSchoolData(school, admin);

        return true;
    }

    //Admin seeding
    private GetAdminDto SeedAdmins()
    {
        var firstName = FirstName.Names[_random.Next(0, FirstName.Names.Count)];
        var lastName = LastName.Names[_random.Next(0, LastName.Names.Count)];
        var isVerified = _random.Next(0, 1);

        var newAdmin = new CreateAdminDto
        {
            Password = "test",
            Username = firstName.ToLower() + "." + lastName.ToLower() + "." + "admin",
            BirthDate = DateTime.Today.Date,
            FirstName = firstName,
            LastName = lastName,
            IsVerified = isVerified != 0,
            VerificationToken = isVerified == 1 ? string.Empty : VerificationToken.CreateVerificationToken(),
            Enabled2FA = false,
        };
        return _adminService.Add(newAdmin);
    }

    //School seeding
    public GetSchoolDto SeedSchool(GetAdminDto getAdminDto)
    {
        var newSchool = new CreateSchoolDto
        {
            Address = Addresses.Locations[_random.Next(0, Addresses.Locations.Count)] + " " + _random.Next(0, 100),
            City = "Mostar",
            Email =  "ju.prva.srednja.skola@gmail.com",
            Fax = "+1-555-123-4567",
            Phone = PhoneNumber.Numbers[_random.Next(0, PhoneNumber.Numbers.Count)],
            PostalCode = "88000",
            SchoolName = "JU Prva Srednja",
            SchoolType = "Srednja",
            AdminId = getAdminDto.Id,

        };
        return _schoolService.Add(newSchool);
    }

    private void SeedSchoolData(GetSchoolDto getSchoolDto, GetAdminDto getAdminDto)
    {
        var allParents = SeedParents(getSchoolDto);
        var allClasses = SeedClasses(getSchoolDto);
        var allTeachers = SeedTeachers(getSchoolDto);
        var allSubjects = SeedSubjects(allTeachers, getSchoolDto);
        var allDepartments = SeedDepartments(allClasses, allTeachers, getSchoolDto);
        var allStudents = SeedStudents(allDepartments, allParents, getSchoolDto);
        SeedNotes(allTeachers, allStudents, getSchoolDto);
        SeedGrades(allStudents, allSubjects, getSchoolDto);
        SeedStudentRules(allStudents, getSchoolDto);
        SeedReports(allStudents, getSchoolDto);
        var allParentMeetings = SeedParentMeetings(allDepartments, getSchoolDto);
        SeedMeetingConfirmations(allParentMeetings, getSchoolDto);
        SeedExams(allDepartments, allSubjects, getSchoolDto);
        var allAbsences = SeedAbsences(allStudents, allSubjects, getSchoolDto);
        SeedParentJustifications(allAbsences, getSchoolDto);
        SeedContactInformations(getAdminDto!, allStudents!, allParents!, allTeachers!);
        SeedEmails(allStudents, allParents, allTeachers, getSchoolDto);
    }

    //Parent seeding
    private List<GetParentDto>? SeedParents(GetSchoolDto getSchoolDto)
    {
        for (var i = 0; i < 100; i++)
        {
            var firstName = FirstName.Names[_random.Next(0, FirstName.Names.Count)];
            var lastName = LastName.Names[_random.Next(0, LastName.Names.Count)];

            var newParent = new CreateParentDto
            {
                Password = "test",
                Username = firstName.ToLower() + "." + lastName.ToLower() + "." + (i + 100),
                BirthDate = DateTime.Today.Date,
                FirstName = firstName,
                LastName = lastName,
                Enabled2FA = false,
                SchoolId = getSchoolDto.Id
            };
            _parentService.Add(newParent);
        }
        return _parentService.GetAll(getSchoolDto.Id);
    }

    //Class seeding
    private List<GetClassDto>? SeedClasses(GetSchoolDto getSchoolDto)
    {
        for (var i = 0; i < 4; i++)
        {
            var newClass = new CreateClassDto
            {
                ClassName = i + 1 + " - razred",
                ClassNumber = i + 1,
                SchoolId = getSchoolDto.Id,
            };
            _classService.Add(newClass);
        }
        return _classService.GetAll(getSchoolDto.Id);
    }

    //Teachers seeding
    private List<GetTeacherDto>? SeedTeachers(GetSchoolDto getSchoolDto)
    {
        for (var i = 0; i < 15; i++)
        {
            var firstName = FirstName.Names[_random.Next(0, FirstName.Names.Count)];
            var lastName = LastName.Names[_random.Next(0, LastName.Names.Count)];

            var newTeacher = new CreateTeacherDto
            {
                Password = "test",
                Username = firstName.ToLower() + "." + lastName.ToLower() + "." + (i + 200),
                BirthDate = DateTime.Today.Date,
                FirstName = firstName,
                LastName = lastName,
                IsClassTeacher = i < 8,
                Enabled2FA = false,
                SchoolId = getSchoolDto.Id
            };
            _teacherService.Add(newTeacher);
        }
        return _teacherService.GetAll(getSchoolDto.Id);
    }

    //Subject seeding
    private List<GetSubjectDto>? SeedSubjects(IReadOnlyList<GetTeacherDto>? teachers, GetSchoolDto getSchoolDto)
    {
        for (var i = 0; i < 15; i++)
        {
            var newSubject = new CreateSubjectDto
            {
                SubjectName = Subjects.SubjectList[i],
                TeacherId = teachers![i].Id,
                SchoolId = getSchoolDto.Id,
            };
            _subjectService.Add(newSubject);
        }
        return _subjectService.GetAll(getSchoolDto.Id);
    }

    //Department seeding
    private List<GetDepartmentDto>? SeedDepartments(IReadOnlyList<GetClassDto>? classes, IReadOnlyList<GetTeacherDto>? teachers, GetSchoolDto getSchoolDto)
    {
        var counter = 0;
        for (var i = 0; i < classes!.Count; i++)
        {
            for (var j = 0; j < 2; j++)
            {
                var newDepartment = new CreateDepartmentDto
                {
                    TeacherId = teachers![i + j + counter].Id,
                    ClassId = classes[i].Id,
                    DepartmentName = j == 0 ? (i + 1) + "a" : i + 1 + "b",
                    DepartmentNumber = j == 0 ? "A" : "B",
                    SchoolId = getSchoolDto.Id,
                };
                _departmentService.Add(newDepartment);
            }
            ++counter;
        }
        return _departmentService.GetAll(getSchoolDto.Id);
    }

    //Student seeding
    private List<GetStudentDto>? SeedStudents(IReadOnlyList<GetDepartmentDto>? departments, IReadOnlyList<GetParentDto>? parents, GetSchoolDto getSchoolDto)
    {
        var departmentIdCounter = 0;
        var parentIdCounter = 0;

        for (var i = 0; i < 200; i++)
        {
            var firstName = FirstName.Names[_random.Next(0, FirstName.Names.Count)];
            var lastName = parents![parentIdCounter].LastName;

            var newStudent = new CreateStudentDto
            {
                Password = "test",
                Username = firstName.ToLower() + "." + lastName.ToLower() + "." + (i + 400),
                BirthDate = DateTime.Today.Date,
                FirstName = firstName,
                LastName = lastName,
                DepartmentId = departments![departmentIdCounter].Id,
                ParentId = parents[parentIdCounter].Id,
                Enabled2FA = false,
                SchoolId = getSchoolDto.Id,
            };
            _studentService.Add(newStudent);

            ++departmentIdCounter;
            ++parentIdCounter;

            if (!(departmentIdCounter < 8))
                departmentIdCounter = 0;

            if (!(parentIdCounter < parents.Count))
                parentIdCounter = 0;
        }
        return _studentService.GetAll(getSchoolDto.Id);
    }

    //Note seeding
    private void SeedNotes(IReadOnlyList<GetTeacherDto>? teachers, IReadOnlyList<GetStudentDto>? students, GetSchoolDto school1)
    {
        for (var i = 0; i < 50; i++)
        {
            var newNote = new CreateNoteDto
            {
                TeacherId = teachers![_random.Next(0, teachers.Count)].Id,
                NoteContent = "Učenik ometa nastavu",
                NoteDate = DateTime.Today.Date,
                StudentId = students![_random.Next(0, students.Count)].Id,
            };
            _noteService.Add(newNote);
        }
    }

    //Grade seeding
    private void SeedGrades(IReadOnlyList<GetStudentDto>? students, IReadOnlyList<GetSubjectDto>? subjects, GetSchoolDto getSchoolDto)
    {
        for (var i = 0; i < 1000; i++)
        {
            var subject = subjects![_random.Next(0, subjects.Count)];
            var newGrade = new CreateGradeDto
            {
                StudentId = students![_random.Next(0, students.Count)].Id,
                GradeNote = subject.SubjectName + " - test",
                GradeValue = _random.Next(1, 6),
                SubjectId = subject.Id,
                SchoolId = getSchoolDto.Id
            };
            _gradeService.Add(newGrade);
        }
    }

    //Student rules seeding
    private void SeedStudentRules(IReadOnlyList<GetStudentDto>? students, GetSchoolDto getSchoolDto)
    {
        for (var i = 0; i < 50; i++)
        {
            var newStudentRule = new CreateStudentRuleDto
            {
                StudentId = students![i].Id,
                RuleDate = DateTime.Today.Date,
                RuleReason = "Nedolično ponašanje",
                RuleValue = _random.Next(1, 5),
                SchoolId = getSchoolDto.Id
            };
            _studentRuleService.Add(newStudentRule);
        }
    }

    //Report seeding
    private void SeedReports(IReadOnlyList<GetStudentDto>? students, GetSchoolDto getSchoolDto)
    {
        foreach (var t in students!)
        {
            var studentId = t.Id;
            var newReport = new CreateReportDto
            {
                StudentId = studentId,
                TeacherId = GetDepartmentsTeacherId(studentId),
                FinalGrade = _random.Next(1, 6),
                StudentRuleId = GetStudentsRuleId(studentId),
                SchoolId = getSchoolDto.Id
            };
            _reportService.Add(newReport);
        }
    }

    private int GetDepartmentsTeacherId(int studentId)
    {
        var student = _context.Students
            .Include(s => s.Department)
            .FirstOrDefault(s => s.Id == studentId);

        return student!.Department.TeacherId;
    }

    private int? GetStudentsRuleId(int studentId)
    {
        var student = _context.Students
            .Include(s => s.StudentRule).FirstOrDefault(s => s.Id == studentId);

        if (student?.StudentRule != null)
            return student.StudentRule.Id;

        return null;
    }

    //Parent meeting seeding
    private List<GetParentMeetingDto>? SeedParentMeetings(IReadOnlyList<GetDepartmentDto>? departments, GetSchoolDto getSchoolDto)
    {
        for (var i = 0; i < 20; i++)
        {
            var newParentMeeting = new CreateParentMeetingDto
            {
                DepartmentId = departments![_random.Next(0, departments.Count)].Id,
                MeetingDate = DateTime.Today.Date,
                PostContent = "Roditeljski sastanak",
                SchoolId = getSchoolDto.Id
            };
            _parentMeetingService.Add(newParentMeeting);
        }
        return _parentMeetingService.GetAll(getSchoolDto.Id);
    }

    //Meeting confirmations seeding
    private void SeedMeetingConfirmations(IReadOnlyList<GetParentMeetingDto>? parentMeetings, GetSchoolDto getSchoolDto)
    {
        foreach (var unused in parentMeetings!)
        {
            var parentMeeting = parentMeetings[_random.Next(0, parentMeetings.Count)];
            var newParentMeetingConfirmation = new CreateMeetingConfirmationDto
            {
                ParentId = GetRandomParentFromDepartment(parentMeeting),
                AttendanceConfirmed = _random.Next(0, 1) != 0,
                ParentMeetingId = parentMeeting.Id,
                SchoolId = getSchoolDto.Id
            };
            _meetingConfirmationService.Add(newParentMeetingConfirmation);
        }
    }

    private int GetRandomParentFromDepartment(GetParentMeetingDto parentMeeting)
    {
        var studentsFromDepartment = _context.Students
            .Where(s => s.DepartmentId == parentMeeting.DepartmentId)
            .ToList();
        var parentIds = studentsFromDepartment.Select(s => s.ParentId).ToList();

        return parentIds[_random.Next(0, parentIds.Count)];
    }

    //Exam seeding
    private void SeedExams(IReadOnlyList<GetDepartmentDto>? departments, IReadOnlyList<GetSubjectDto>? subjects, GetSchoolDto getSchoolDto)
    {
        for (var i = 0; i < 50; i++)
        {
            var subject = subjects![_random.Next(0, subjects.Count())];
            var newExam = new CreateExamDto
            {
                DepartmentId = departments![_random.Next(0, departments.Count)].Id,
                TeacherId = subject.TeacherId,
                PostContent = "Test iz predmeta " + subject.SubjectName.ToLower(),
                SubjectId = subject.Id,
                ExamDate = DateTime.Today.Date,
                ExamName = "Test",
                SchoolId = getSchoolDto.Id
            };
            _examService.Add(newExam);
        }
    }

    //Absence seeding
    private List<GetAbsenceDto>? SeedAbsences(IReadOnlyList<GetStudentDto>? students, IReadOnlyList<GetSubjectDto>? subjects, GetSchoolDto getSchoolDto)
    {
        for (var i = 0; i < 20; i++)
        {
            var subject = subjects![_random.Next(0, subjects.Count)];

            var newAbsence = new CreateAbsenceDto
            {
                StudentId = students![_random.Next(0, students.Count)].Id,
                TeacherId = subject.TeacherId,
                Justified = i < 10,
                Lecture = subject.SubjectName,
                AbsenceDate = DateTime.Today.Date,
                AbsenceNote = "Učenik nije bio prisutan na nastavi",
                SchoolId = getSchoolDto.Id
            };
            _absenceService.Add(newAbsence);
        }
        return _absenceService.GetAll(getSchoolDto.Id);
    }

    //ParentJustification seeding
    private void SeedParentJustifications(IReadOnlyList<GetAbsenceDto>? absences, GetSchoolDto getSchoolDto)
    {
        for (var i = 0; i < absences!.Count / 2; i++)
        {
            var absence = absences[i];
            var newParentJustification = new CreateParentJustificationDto
            {
                ParentId = GetParentByAbsence(absence),
                AbsenceId = absence.Id,
                JustificationDate = DateTime.Today.Date,
                JustificationReason = "Potvrda od kućnog liječnika",
                SchoolId = getSchoolDto.Id
            };
            _parentJustificationService.Add(newParentJustification);
        }
    }

    private int GetParentByAbsence(GetAbsenceDto absence)
    {
        var response = _context.Absences
            .Include(a => a.Student)
            .FirstOrDefault(a => a.Id == absence.Id);

        return response!.Student.ParentId;
    }

    //Contact information seeding
    private void SeedContactInformations(GetAdminDto admin, IEnumerable<GetStudentDto> students, IEnumerable<GetParentDto> parents, IEnumerable<GetTeacherDto> teachers)
    {
        var adminContactInformation = new CreateContactInformationDto()
        {
            Address = Addresses.Locations[_random.Next(0, Addresses.Locations.Count)],
            PostalCode = "88000",
            City = "Mostar",
            Email = admin.FirstName.ToLower() + "." + admin.LastName.ToLower() + "." + _random.Next(1, 1000) + "@gmail.com",
            Phone = PhoneNumber.Numbers[_random.Next(0, PhoneNumber.Numbers.Count)],
            UserId = admin.Id,
        };
        _contactInformationService.Add(adminContactInformation);

        foreach (var newContactInformation in students.Select(t => new CreateContactInformationDto()
        {
            Address = Addresses.Locations[_random.Next(0, Addresses.Locations.Count)],
            PostalCode = "88000",
            City = "Mostar",
            Email = t.FirstName.ToLower() + "." + t.LastName.ToLower() + "." + _random.Next(1, 1000) + "@gmail.com",
            Phone = PhoneNumber.Numbers[_random.Next(0, PhoneNumber.Numbers.Count)],
            UserId = t.Id,
        }))
        {
            _contactInformationService.Add(newContactInformation);
        }
        foreach (var newContactInformation in parents.Select(t => new CreateContactInformationDto()
        {
            Address = Addresses.Locations[_random.Next(0, Addresses.Locations.Count)],
            PostalCode = "88000",
            City = "Mostar",
            Email = t.FirstName.ToLower() + "." + t.LastName.ToLower() + "." + _random.Next(1, 1000) + "@gmail.com",
            Phone = PhoneNumber.Numbers[_random.Next(0, PhoneNumber.Numbers.Count)],
            UserId = t.Id,
        }))
        {
            _contactInformationService.Add(newContactInformation);
        }

        foreach (var newContactInformation in teachers.Select(t => new CreateContactInformationDto()
        {
            Address = Addresses.Locations[_random.Next(0, Addresses.Locations.Count)] + " " + _random.Next(1, 100),
            PostalCode = "88000",
            City = "Mostar",
            Email = t.FirstName.ToLower() + "." + t.LastName.ToLower() + "." + _random.Next(1, 1000) + "@gmail.com",
            Phone = PhoneNumber.Numbers[_random.Next(0, PhoneNumber.Numbers.Count)],
            UserId = t.Id,
        }))
        {
            _contactInformationService.Add(newContactInformation);
        }
    }

    //Email seeding
    private void SeedEmails(IReadOnlyList<GetStudentDto>? students, IReadOnlyList<GetParentDto>? parents, IReadOnlyList<GetTeacherDto>? teachers, GetSchoolDto getSchoolDto)
    {
        for (var i = 0; i < 10; i++)
        {
            var newEmail = new CreateEmailDto
            {
                UserId = students![_random.Next(0, students.Count())].Id,
                Content = "Poštovanji/a profesore/ice, obraćam Vam se radi (...)",
                Subject = "Pitanje vezano za (...)",
            };
            _emailService.Add(newEmail);
        }

        for (var i = 0; i < 10; i++)
        {
            var newEmail = new CreateEmailDto
            {
                UserId = parents![_random.Next(0, parents.Count())].Id,
                Content = "Poštovanje, da li (...)",
                Subject = "Molba za (...)",
            };
            _emailService.Add(newEmail);
        }

        for (var i = 0; i < 10; i++)
        {
            var newEmail = new CreateEmailDto
            {
                UserId = teachers![_random.Next(0, teachers.Count())].Id,
                Content = "Poštovani (...), odgovor na tekst vašeg maila je slijedeći: (...)",
                Subject = "Odgovor na (...)",
            };
            _emailService.Add(newEmail);
        }
    }
}