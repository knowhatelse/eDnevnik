﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eDnevnik___backend.Data;

#nullable disable

namespace eDnevnik___backend.Migrations
{
    [DbContext(typeof(eDnevnikDbContext))]
    [Migration("20240522010048_Updated")]
    partial class Updated
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("eDnevnik___backend.Entities.Absence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AbsenceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AbsenceNote")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Justified")
                        .HasColumnType("bit");

                    b.Property<string>("Lecture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShoolId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Absences");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClassNumber")
                        .HasColumnType("int");

                    b.Property<int>("SchoolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.ClassSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("ShoolId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("SubjectId");

                    b.ToTable("ClassSubjects");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.ContactInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("ContactInformations");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShoolId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("TeacherId")
                        .IsUnique();

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExamDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShoolId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfAssessment")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FinalGrade")
                        .HasColumnType("int");

                    b.Property<string>("GradeNote")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GradeValue")
                        .HasColumnType("int");

                    b.Property<int>("ShoolId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.MeetingConfirmation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AttendanceConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("ParentMeetingId")
                        .HasColumnType("int");

                    b.Property<int>("ShoolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("ParentMeetingId");

                    b.ToTable("MeetingConfirmations");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NoteContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NoteDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ShoolId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.ParentJustification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AbsenceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("JustificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("JustificationReason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("ShoolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AbsenceId")
                        .IsUnique();

                    b.HasIndex("ParentId");

                    b.ToTable("ParentJustifications");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.ParentMeeting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("MeetingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PostContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShoolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("ParentMeetings");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("FinalGrade")
                        .HasColumnType("real");

                    b.Property<int>("ShoolId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentRuleId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.HasIndex("StudentRuleId")
                        .IsUnique()
                        .HasFilter("[StudentRuleId] IS NOT NULL");

                    b.HasIndex("TeacherId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId")
                        .IsUnique();

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.StudentRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("RuleDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RuleReason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RuleValue")
                        .HasColumnType("int");

                    b.Property<int>("ShoolId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("StudentRules");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ShoolId")
                        .HasColumnType("int");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Enabled2FA")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SchoolId")
                        .HasColumnType("int");

                    b.Property<string>("Token2FA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.Admin", b =>
                {
                    b.HasBaseType("eDnevnik___backend.Entities.User");

                    b.Property<bool?>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<string>("VerificationToken")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.Parent", b =>
                {
                    b.HasBaseType("eDnevnik___backend.Entities.User");

                    b.HasDiscriminator().HasValue("Parent");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.Student", b =>
                {
                    b.HasBaseType("eDnevnik___backend.Entities.User");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("ParentId");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.Teacher", b =>
                {
                    b.HasBaseType("eDnevnik___backend.Entities.User");

                    b.Property<bool>("IsClassTeacher")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("Teacher");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.Absence", b =>
                {
                    b.HasOne("eDnevnik___backend.Entities.Student", "Student")
                        .WithMany("Absences")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eDnevnik___backend.Entities.Teacher", "Teacher")
                        .WithMany("Absences")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.Class", b =>
                {
                    b.HasOne("eDnevnik___backend.Entities.School", "School")
                        .WithMany("Classes")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.ClassSubject", b =>
                {
                    b.HasOne("eDnevnik___backend.Entities.Class", "Class")
                        .WithMany("ClassSubjects")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eDnevnik___backend.Entities.Subject", "Subject")
                        .WithMany("ClassSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.ContactInformation", b =>
                {
                    b.HasOne("eDnevnik___backend.Entities.User", "User")
                        .WithOne("ContactInformation")
                        .HasForeignKey("eDnevnik___backend.Entities.ContactInformation", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.Department", b =>
                {
                    b.HasOne("eDnevnik___backend.Entities.Class", "Class")
                        .WithMany("Departments")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eDnevnik___backend.Entities.Teacher", "Teacher")
                        .WithOne("Department")
                        .HasForeignKey("eDnevnik___backend.Entities.Department", "TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.Email", b =>
                {
                    b.HasOne("eDnevnik___backend.Entities.User", "User")
                        .WithMany("Emails")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.Exam", b =>
                {
                    b.HasOne("eDnevnik___backend.Entities.Department", "Department")
                        .WithMany("Exams")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eDnevnik___backend.Entities.Subject", "Subject")
                        .WithMany("Exams")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eDnevnik___backend.Entities.Teacher", "Teacher")
                        .WithMany("Exams")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.Grade", b =>
                {
                    b.HasOne("eDnevnik___backend.Entities.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eDnevnik___backend.Entities.Subject", "Subject")
                        .WithMany("Grades")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.MeetingConfirmation", b =>
                {
                    b.HasOne("eDnevnik___backend.Entities.Parent", "Parent")
                        .WithMany("MeetingConfirmations")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eDnevnik___backend.Entities.ParentMeeting", "ParentMeeting")
                        .WithMany("MeetingConfirmations")
                        .HasForeignKey("ParentMeetingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");

                    b.Navigation("ParentMeeting");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.Note", b =>
                {
                    b.HasOne("eDnevnik___backend.Entities.Student", "Student")
                        .WithMany("Notes")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eDnevnik___backend.Entities.Teacher", "Teacher")
                        .WithMany("Notes")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.ParentJustification", b =>
                {
                    b.HasOne("eDnevnik___backend.Entities.Absence", "Absence")
                        .WithOne("ParentJustification")
                        .HasForeignKey("eDnevnik___backend.Entities.ParentJustification", "AbsenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eDnevnik___backend.Entities.Parent", "Parent")
                        .WithMany("ParentJustifications")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Absence");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.ParentMeeting", b =>
                {
                    b.HasOne("eDnevnik___backend.Entities.Department", "Department")
                        .WithMany("ParentMeetings")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.Report", b =>
                {
                    b.HasOne("eDnevnik___backend.Entities.Student", "Student")
                        .WithOne("Report")
                        .HasForeignKey("eDnevnik___backend.Entities.Report", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eDnevnik___backend.Entities.StudentRule", "StudentRule")
                        .WithOne("Report")
                        .HasForeignKey("eDnevnik___backend.Entities.Report", "StudentRuleId");

                    b.HasOne("eDnevnik___backend.Entities.Teacher", "Teacher")
                        .WithMany("Reports")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("StudentRule");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.School", b =>
                {
                    b.HasOne("eDnevnik___backend.Entities.Admin", "Admin")
                        .WithOne("School")
                        .HasForeignKey("eDnevnik___backend.Entities.School", "AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.StudentRule", b =>
                {
                    b.HasOne("eDnevnik___backend.Entities.Student", "Student")
                        .WithOne("StudentRule")
                        .HasForeignKey("eDnevnik___backend.Entities.StudentRule", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.Subject", b =>
                {
                    b.HasOne("eDnevnik___backend.Entities.Teacher", "Teacher")
                        .WithMany("Subjects")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.Student", b =>
                {
                    b.HasOne("eDnevnik___backend.Entities.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eDnevnik___backend.Entities.Parent", "Parent")
                        .WithMany("Students")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.Absence", b =>
                {
                    b.Navigation("ParentJustification");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.Class", b =>
                {
                    b.Navigation("ClassSubjects");

                    b.Navigation("Departments");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.Department", b =>
                {
                    b.Navigation("Exams");

                    b.Navigation("ParentMeetings");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.ParentMeeting", b =>
                {
                    b.Navigation("MeetingConfirmations");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.School", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.StudentRule", b =>
                {
                    b.Navigation("Report");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.Subject", b =>
                {
                    b.Navigation("ClassSubjects");

                    b.Navigation("Exams");

                    b.Navigation("Grades");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.User", b =>
                {
                    b.Navigation("ContactInformation");

                    b.Navigation("Emails");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.Admin", b =>
                {
                    b.Navigation("School");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.Parent", b =>
                {
                    b.Navigation("MeetingConfirmations");

                    b.Navigation("ParentJustifications");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.Student", b =>
                {
                    b.Navigation("Absences");

                    b.Navigation("Grades");

                    b.Navigation("Notes");

                    b.Navigation("Report");

                    b.Navigation("StudentRule");
                });

            modelBuilder.Entity("eDnevnik___backend.Entities.Teacher", b =>
                {
                    b.Navigation("Absences");

                    b.Navigation("Department");

                    b.Navigation("Exams");

                    b.Navigation("Notes");

                    b.Navigation("Reports");

                    b.Navigation("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
