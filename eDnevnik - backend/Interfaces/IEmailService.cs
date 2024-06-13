using eDnevnik___backend.DTOs.AuthenticationDto;
using eDnevnik___backend.DTOs.EmailDto;
using eDnevnik___backend.DTOs.VerificationDto;

namespace eDnevnik___backend.Interfaces;

public interface IEmailService : IBaseCRUDService<GetEmailDto, CreateEmailDto, UpdateEmailDto>
{ 
    VerificationResponseDto SendVerificationEmail(AccountVerificationDto request);
}