using eDnevnik___backend.DTOs.VerificationDto;
using eDnevnik___backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik___backend.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class VerificationController(IVerificationService verificationService) : Controller
{
    private readonly IVerificationService _verificationService = verificationService;

    [AllowAnonymous]
    [HttpPost("VerifyUserAccount")]
    public ActionResult VerifyUserAccount(TokenVerificationDto request) //Preimenovati u VerifyUserRegister
    {
        var response = _verificationService.RegisterVerification(request);

        if (response.StatusCode == 200)
        {
           return Ok(response);
        }

        if (response.StatusCode == 404)
        {
            return NotFound(response);
        }

        return BadRequest(response);
    }

    [AllowAnonymous]
    [HttpPost("ResendVerificationEmail/{userId:int}")]
    public ActionResult ResendVerificationEmail(int userId)
    {
        var response = _verificationService.ResendRegisterVerificationToken(userId);
        if (response.StatusCode != 200)
        {
            //Provjeriti i za ostale statusne kodove
            return BadRequest(response);
        }

        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("VerifyUserLogin")]
    public ActionResult VerifyUserLogin(TokenVerificationDto request)
    {
        var response = _verificationService.LoginVerification(request);

        if (response.StatusCode != 200)
        {
           return Unauthorized(response);
        }

        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("ResednAuthenticationSMS/{userId:int}")]
    public ActionResult ResendAuthenticationSMS(int userId)
    {
        var response = _verificationService.ResendLoginVerificationToken(userId);

        if (response.StatusCode != 200)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
}