using AutoMapper;
using eDnevnik___backend.DTOs.AbsenceDto;
using eDnevnik___backend.DTOs.AdminDto;
using eDnevnik___backend.DTOs.AuthenticationDto;
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
using eDnevnik___backend.DTOs.UserDto;
using eDnevnik___backend.Entities;

namespace eDnevnik___backend;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<RegisterDto, CreateAdminDto>();
        CreateMap<RegisterDto, CreateContactInformationDto>();

        CreateMap<Absence, GetAbsenceDto>().ForMember(dest => dest.Teacher, opt => opt.MapFrom(src => src.Teacher.FirstName + ' ' + src.Teacher.LastName));
        CreateMap<CreateAbsenceDto, Absence>();
        CreateMap<UpdateAbsenceDto, Absence>();

        CreateMap<Admin, GetAdminDto>();
        CreateMap<CreateAdminDto, Admin>();
        CreateMap<UpdateAdminDto, Admin>();
        CreateMap<GetAdminDto, UpdateAdminDto>();

        CreateMap<Class, GetClassDto>();
        CreateMap<CreateClassDto, Class>();
        CreateMap<UpdateClassDto, Class>();

        CreateMap<ContactInformation, GetContactInformationDto>();
        CreateMap<CreateContactInformationDto, ContactInformation>();
        CreateMap<UpdateContactInformationDto, ContactInformation>();

        CreateMap<Department, GetDepartmentDto>();
        CreateMap<CreateDepartmentDto, Department>();
        CreateMap<UpdateDepartmentDto, Department>();

        CreateMap<Email, GetEmailDto>();
        CreateMap<CreateEmailDto, Email>();
        CreateMap<UpdateEmailDto, Email>();

        CreateMap<Exam, GetExamDto>().ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject.SubjectName));;
        CreateMap<CreateExamDto, Exam>();
        CreateMap<UpdateExamDto, Exam>();

        CreateMap<Grade, GetGradeDto>().ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject.SubjectName));
        CreateMap<CreateGradeDto, Grade>();
        CreateMap<UpdateGradeDto, Grade>();

        CreateMap<MeetingConfirmation, GetMeetingConfirmationDto>();
        CreateMap<CreateMeetingConfirmationDto, MeetingConfirmation>();
        CreateMap<UpdateMeetingConfirmationDto, MeetingConfirmation>();

        CreateMap<Note, GetNoteDto>().ForMember(dest => dest.Teacher, opt => opt.MapFrom(src => src.Teacher.FirstName + ' ' + src.Teacher.LastName));
        CreateMap<CreateNoteDto, Note>();
        CreateMap<UpdateNoteDto, Note>();

        CreateMap<Parent, GetParentDto>().ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Students));
        CreateMap<CreateParentDto, Parent>();
        CreateMap<UpdateParentDto, Parent>();
        CreateMap<GetParentDto, UpdateParentDto>();

        CreateMap<ParentJustification, GetParentJustificationDto>();
        CreateMap<CreateParentJustificationDto, ParentJustification>();
        CreateMap<UpdateParentJustificationDto, ParentJustification>();

        CreateMap<ParentMeeting, GetParentMeetingDto>();
        CreateMap<CreateParentMeetingDto, ParentMeeting>();
        CreateMap<UpdateParentMeetingDto, ParentMeeting>();

        CreateMap<Report, GetReportDto>();
        CreateMap<CreateReportDto, Report>();
        CreateMap<UpdateReportDto, Report>();

        CreateMap<School, GetSchoolDto>();
        CreateMap<CreateSchoolDto, School>();
        CreateMap<UpdateSchoolDto, School>();

        CreateMap<Student, GetStudentDto>();
        CreateMap<CreateStudentDto, Student>();
        CreateMap<UpdateStudentDto, Student>();
        CreateMap<GetStudentDto, UpdateStudentDto>();

        CreateMap<StudentRule, GetStudentRuleDto>();
        CreateMap<CreateStudentRuleDto, StudentRule>();
        CreateMap<UpdateStudentRuleDto, StudentRule>();

        CreateMap<Subject, GetSubjectDto>();
        CreateMap<CreateSubjectDto, Subject>();
        CreateMap<UpdateSubjectDto, Subject>();

        CreateMap<Teacher, GetTeacherDto>();
        CreateMap<CreateTeacherDto, Teacher>();
        CreateMap<UpdateTeacherDto, Teacher>();
        CreateMap<GetTeacherDto, UpdateTeacherDto>();

        CreateMap<User, GetUserDto>();
        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>();
        CreateMap<GetUserDto, UpdateUserDto>();
    }
}