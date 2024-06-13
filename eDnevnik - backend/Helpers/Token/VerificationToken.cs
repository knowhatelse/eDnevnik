using System.Text;
using AutoMapper;
using eDnevnik___backend.Data;
using eDnevnik___backend.DTOs.AdminDto;
using eDnevnik___backend.DTOs.ParentDto;
using eDnevnik___backend.DTOs.StudentDto;
using eDnevnik___backend.DTOs.TeacherDto;
using eDnevnik___backend.DTOs.UserDto;
using eDnevnik___backend.Services;

namespace eDnevnik___backend.Helpers;

public class VerificationToken
{
    private readonly static  Random _random = new();

    public static string CreateVerificationToken()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var codeBuilder = new StringBuilder(6);

        for (var i = 0; i < 6; i++)
        {
            var index = _random.Next(chars.Length);
            codeBuilder.Append(chars[index]);
        }

        return codeBuilder.ToString();
    }
}