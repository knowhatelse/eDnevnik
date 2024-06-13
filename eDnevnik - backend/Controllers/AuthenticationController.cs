using eDnevnik___backend.DTOs.AuthenticationDto;
using eDnevnik___backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik___backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController(IAuthenticatorService authenticatorService) : ControllerBase
    {
        private readonly IAuthenticatorService _authenticatorService = authenticatorService;

        [HttpPost("Register")]
        public ActionResult Register(RegisterDto request)
        {
            var response = _authenticatorService.Register(request);

            if (response.StatusCode == 400)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("Login")]
        public ActionResult Login(LoginDto request)
        {
            var response = _authenticatorService.Login(request);

            if (response.StatusCode != 200)
            {
                switch (response.StatusCode)
                {
                    case 401: return Unauthorized(response);
                    case 403: return new ObjectResult(response) { StatusCode = 403 };
                    case 404: return NotFound(response);
                }
            }

            return Ok(response);
        }
    }
}
