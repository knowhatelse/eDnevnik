using eDnevnik___backend;
using eDnevnik___backend.Data;
using eDnevnik___backend.Helpers;
using eDnevnik___backend.Interfaces;
using eDnevnik___backend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<eDnevnikDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("eDnevnikConnectionString")));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetSection("JWT");

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Issuer"],
            ValidAudience = configuration["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Key"]!))
        };

    });

builder.Services.AddControllers();
builder.Services.AddCors();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);


//Entities services
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IAdminService, AdminService>();
builder.Services.AddTransient<IParentService, ParentService>();
builder.Services.AddTransient<ITeacherService, TeacherService>();
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<ISchoolService, SchoolService>();
builder.Services.AddTransient<ISubjectService, SubjectService>();
builder.Services.AddTransient<IClassService, ClassService>();
builder.Services.AddTransient<IGradeService, GradeService>();
builder.Services.AddTransient<IAbsenceService, AbsenceService>();
builder.Services.AddTransient<IContactInformationService, ContactInformationService>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<IExamService, ExamService>();
builder.Services.AddTransient<IMeetingConfirmationService, MeetingConfirmationService>();
builder.Services.AddTransient<INoteService, NoteService>();
builder.Services.AddTransient<IParentJustificationService, ParentJustificationService>();
builder.Services.AddTransient<IParentMeetingService, ParentMeetingService>();
builder.Services.AddTransient<IReportService, ReportService>();
builder.Services.AddTransient<IStudentRuleService, StudentRuleService>();
builder.Services.AddTransient<IDepartmentService, DepartmentService>();
builder.Services.AddTransient<IAuthenticatorService, AuthenticatorService>();
builder.Services.AddTransient<IVerificationService, VerificationService>();


//Data seeder service
builder.Services.AddTransient<IDataSeeder, DataSeeder>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();