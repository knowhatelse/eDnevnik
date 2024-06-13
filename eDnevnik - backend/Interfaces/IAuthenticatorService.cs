using eDnevnik___backend.DTOs.AuthenticationDto;
using eDnevnik___backend.DTOs.VerificationDto;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik___backend.Interfaces
{
    public interface IAuthenticatorService
    {
        VerificationResponseDto Register(RegisterDto request);
        
        VerificationResponseDto Login(LoginDto request);
    }
}
