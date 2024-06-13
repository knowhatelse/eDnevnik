using AutoMapper;
using eDnevnik___backend.Data;
using eDnevnik___backend.DTOs.AuthenticationDto;
using eDnevnik___backend.DTOs.EmailDto;
using eDnevnik___backend.DTOs.VerificationDto;
using eDnevnik___backend.Entities;
using eDnevnik___backend.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace eDnevnik___backend.Services;

public class EmailService : BaseCRUDService<Email, GetEmailDto, CreateEmailDto, UpdateEmailDto>, IEmailService
{
    private readonly IConfiguration _emailSettings;

    public EmailService(eDnevnikDbContext context, IMapper mapper) : base(context, mapper)
    {
        _emailSettings = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        _emailSettings = _emailSettings.GetSection("EmailSettings");
    }

    public VerificationResponseDto SendVerificationEmail(AccountVerificationDto request)
    {
        var message = new VerificationResponseDto { StatusCode = 200, StatusMessage = "Verification email has been sent." };
        var htmlContent = File.ReadAllText(_emailSettings["HtmlTemplatePath"]!);
        var email = new MimeMessage();
        
        email.From.Add(new MailboxAddress(_emailSettings["SenderName"], _emailSettings["SenderEmail"]));
        
        try { email.To.Add(new MailboxAddress(request.UserName, request.UserEmail)); }
        catch (Exception)
        {
            message.StatusCode = 400;
            message.StatusMessage = "Invalid user email.";
            return message;
        }
        
        email.Subject = "Account verification";
        email.Body = new TextPart(TextFormat.Html) { Text = htmlContent.Replace("{VerificationToken}", request.VerificationToken) };
        
        using var smtp = new SmtpClient();
        smtp.Connect(_emailSettings["Host"], int.Parse(_emailSettings["Port"]!), SecureSocketOptions.StartTls);
        smtp.Authenticate(_emailSettings["Username"], _emailSettings["Password"]);
        
        try { smtp.Send(email); }
        catch (Exception)
        {
            message.StatusCode = 400;
            message.StatusMessage = "Invalid user email.";
            return message;
        }
        smtp.Disconnect(true);
        
        return message;
    }
    
}