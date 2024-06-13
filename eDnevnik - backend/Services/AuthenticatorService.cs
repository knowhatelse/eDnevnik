using AutoMapper;
using eDnevnik___backend.Data;
using eDnevnik___backend.DTOs.AdminDto;
using eDnevnik___backend.DTOs.AuthenticationDto;
using eDnevnik___backend.DTOs.ContactInformationDto;
using eDnevnik___backend.DTOs.UserDto;
using eDnevnik___backend.DTOs.VerificationDto;
using eDnevnik___backend.Helpers;
using eDnevnik___backend.Interfaces;


namespace eDnevnik___backend.Services
{
    public class AuthenticatorService(eDnevnikDbContext context, IMapper mapper) : IAuthenticatorService
    {
        private readonly eDnevnikDbContext _context = context;
        private readonly IMapper _mapper = mapper;
        private readonly IContactInformationService _contactInformationService = new ContactInformationService(context, mapper);

        public VerificationResponseDto Register(RegisterDto request)
        {
            var adminService = new AdminService(_context, _mapper);
            var emailService = new EmailService(_context, _mapper);

            var verificationToken = VerificationToken.CreateVerificationToken();

            var verificationResponse = emailService.SendVerificationEmail(new AccountVerificationDto
            {
                VerificationToken = verificationToken,
                UserEmail = request.Email,
                UserName = request.FirstName + " " + request.LastName
            });

            if (verificationResponse.StatusCode != 200)
            {
                return verificationResponse;
            };

            var newAdmin = _mapper.Map<CreateAdminDto>(request);
            newAdmin.VerificationToken = verificationToken;
            newAdmin.IsVerified = false;
            
            var response = adminService.Add(newAdmin);
           
            var newAdminContactInfo = _mapper.Map<CreateContactInformationDto>(request);
            newAdminContactInfo.UserId = response.Id;
            _contactInformationService.Add(newAdminContactInfo);
            
            verificationResponse.UserId = response.Id;
            verificationResponse.Role = response.Role;

            return verificationResponse;
        }

        public VerificationResponseDto Login(LoginDto request)
        {
            var response = new VerificationResponseDto { StatusCode = 404, StatusMessage = "Neispravno korisničko ime ili šifra" }; ;
            var userService = new UserService(_context, _mapper);

            var user = userService.GetByUsername(request.Username);
            if (user is null) return response;

            var passwordCheck = PasswordCheck.CheckPasswords(user.PasswordSalt, user.PasswordHash, request.Password);
            if (passwordCheck == false) return response;

            if (user.Role == "Admin")
            {
                var adminService = new AdminService(_context, _mapper);
                var admin = adminService.GetByUsername(request.Username);

                if (admin!.IsVerified != true)
                {
                    response.UserId = user.Id;
                    response.Role = user.Role;
                    response.StatusCode = 403;
                    response.StatusMessage = "Nalog nije verificiran";
                    return response;
                }
            }

            if (user.Enabled2FA == true)
            {
                var token = VerificationToken.CreateVerificationToken();
                user.Token2FA = token;

                userService.Update(user.Id, _mapper.Map<UpdateUserDto>(user));

                var userContactInfo = _contactInformationService.GetById(user.Id) as GetContactInformationDto;

                // var smsSender = new SMSSender();
                // smsSender.SendSMS(userContactInfo!.Phone, token);

                // !--------------------------------------------------------------------------------------------------------->
                // ! Email servis se koristi radi potrebe testiranja jer se SMS servis plaća po poslanij poruci.
                var emailService = new EmailService(_context, _mapper);
                emailService.SendVerificationEmail(new AccountVerificationDto()
                {
                    VerificationToken = token,
                    UserEmail = userContactInfo!.Email,
                    UserName = string.Empty
                });
                // !<---------------------------------------------------------------------------------------------------------

                response.UserId = user.Id;
                response.Role = user.Role;
                response.StatusCode = 401;
                response.StatusMessage = "Potreban je kod za autentifikaciju";

                return response;
            }

            var jwtToken = new JwtToken().CreateToken(user);

            response.UserId = user.Id;
            response.Role = user.Role;
            response.StatusCode = 200;
            response.StatusMessage = "Uspiješno ste se prijavili";
            response.JwtToken = jwtToken;

            return response;
        }

    }
}
