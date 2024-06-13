using AutoMapper;
using eDnevnik___backend.Data;
using eDnevnik___backend.DTOs.AdminDto;
using eDnevnik___backend.DTOs.AuthenticationDto;
using eDnevnik___backend.DTOs.ContactInformationDto;
using eDnevnik___backend.DTOs.UserDto;
using eDnevnik___backend.DTOs.VerificationDto;
using eDnevnik___backend.Helpers;
using eDnevnik___backend.Interfaces;

namespace eDnevnik___backend.Services;

public class VerificationService(eDnevnikDbContext context, IMapper mapper) : IVerificationService
{
    private readonly eDnevnikDbContext _context = context;
    private readonly IMapper _mapper = mapper;
    private readonly IAdminService _adminService = new AdminService(context, mapper);
    private readonly IContactInformationService _contactInformationService = new ContactInformationService(context, mapper);
    private readonly IEmailService _emailService = new EmailService(context, mapper);

    public VerificationResponseDto RegisterVerification(TokenVerificationDto request)
    {
        var user = _adminService.GetById(request.UserId) as GetAdminDto;
        var tokenVerificationResponse = new VerificationResponseDto {StatusCode = 200, StatusMessage = "Nalog je uspiješno verificiran"};
        
        if ( user == null)
        {
            tokenVerificationResponse.StatusCode = 404;
            tokenVerificationResponse.StatusMessage = "Nalog nije pronađen";
            return tokenVerificationResponse;
        }

        if (string.IsNullOrEmpty(request.VerificationToken) || request.VerificationToken != user.VerificationToken)
        {
            tokenVerificationResponse.StatusCode = 400;
            tokenVerificationResponse.StatusMessage = "Neispravan verifikacijski kod";
            return tokenVerificationResponse;
        }
        
        user.VerificationToken = string.Empty;
        user.IsVerified = true;
        
        var updatedUser = _mapper.Map<UpdateAdminDto>(user);
        _adminService.Update(request.UserId, updatedUser);

        var jwtToken = new JwtToken();
        var userToken = jwtToken.CreateToken(user);

        tokenVerificationResponse.UserId = user.Id;
        tokenVerificationResponse.Role = user.Role;
        tokenVerificationResponse.JwtToken = userToken;

        return tokenVerificationResponse;
    }

    public VerificationResponseDto ResendRegisterVerificationToken(int userId)
    {
        if (_adminService.GetById(userId) is not GetAdminDto user)
        {
            return new VerificationResponseDto { StatusCode = 404, StatusMessage = "Nalog nije pronađen" };
        }

        var userContactInfo = (GetContactInformationDto)_contactInformationService.GetById(userId)!;
        var newToken = VerificationToken.CreateVerificationToken();

        user.VerificationToken = newToken;
        
        var updatedUser = _mapper.Map<UpdateAdminDto>(user);
        _adminService.Update(userId, updatedUser);

        var verificationEmailRequest = new AccountVerificationDto()
        {
            VerificationToken = newToken,
            UserEmail = userContactInfo.Email,
            UserName = user.FirstName + " " + user.LastName
        };

        var emailVerificationResponse = _emailService.SendVerificationEmail(verificationEmailRequest);
        if (emailVerificationResponse.StatusCode != 200 )
        {
            return emailVerificationResponse;
        };

        return emailVerificationResponse;

    }
    

    public VerificationResponseDto LoginVerification(TokenVerificationDto request)
    {
        var response = new VerificationResponseDto() { StatusCode = 400, StatusMessage = "Neispravan autentifikacijski kod" };

        var userService = new UserService(_context, _mapper);
        var user = userService.GetById(request.UserId) as GetUserDto;
        
        if (user!.Token2FA != request.VerificationToken) return response;

        user.Token2FA = string.Empty;

        userService.Update(user.Id, _mapper.Map<UpdateUserDto>(user));

        var jwtToken = new JwtToken().CreateToken(user);
      
        response.UserId = user.Id;
        response.Role = user.Role;
        response.StatusCode = 200;
        response.StatusMessage = "Uspiješno ste se prijavili";
        response.JwtToken = jwtToken;

        return response;
    }

    public VerificationResponseDto ResendLoginVerificationToken(int userId)
    {
        var userService = new UserService(_context, _mapper);

        if (userService.GetById(userId) is not GetUserDto user)
        {
            return new VerificationResponseDto()
            {
                StatusCode = 404,
                StatusMessage = "Nalog nije pronađen"
            };
        }

        var contactInformationService = new ContactInformationService(_context, _mapper);
        var userContactInfo = contactInformationService.GetById(user.Id) as GetContactInformationDto;
        var verificationToken = VerificationToken.CreateVerificationToken();

        user.Token2FA = verificationToken;
        userService.Update(user.Id, _mapper.Map<UpdateUserDto>(user));

        // var smsSender = new SMSSender();
        // smsSender.SendSMS(userContactInfo!.Phone, verificationToken);

        // ! ------------------------------------------------------------------------------------------------------------------------>
        // ! Email servis se koristi radi potrebe testiranja jer se SMS servis plaća po poslanij poruci.
        var emailService = new EmailService(_context, _mapper);
        var accountCerification = new AccountVerificationDto()
        {
            VerificationToken = verificationToken,
            UserEmail = userContactInfo!.Email,
            UserName = string.Empty
        };
        emailService.SendVerificationEmail(accountCerification);
        // ! <------------------------------------------------------------------------------------------------------------------------

        return new VerificationResponseDto
        {
            StatusCode = 200,
            StatusMessage = "Novi verifikacijski kod vam je poslan"
        };
    }
}