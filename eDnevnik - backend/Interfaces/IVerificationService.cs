using eDnevnik___backend.DTOs.VerificationDto;

namespace eDnevnik___backend.Interfaces;

public interface IVerificationService
{
    VerificationResponseDto RegisterVerification(TokenVerificationDto request);
    VerificationResponseDto ResendRegisterVerificationToken(int userId);
    VerificationResponseDto LoginVerification(TokenVerificationDto request);
    VerificationResponseDto ResendLoginVerificationToken(int userId);
}