using AutoMapper;
using eDnevnik___backend.Data;
using eDnevnik___backend.DTOs.UserDto;
using eDnevnik___backend.Entities;

namespace eDnevnik___backend.Services;

public class UserService(eDnevnikDbContext context, IMapper mapper)
    : BaseUserService<User, GetUserDto, CreateUserDto, UpdateUserDto>(context, mapper), IUserService
{
    private readonly eDnevnikDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public GetUserPasswordDto? GetUserPassword(int id)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == id);

        if (user == null)
        {
            return null;
        }

        return new GetUserPasswordDto
        {
            Hash = user.PasswordHash,
            Salt = user.PasswordSalt
        };
    }

    public bool UpdateUserPassword(int id, string userPassword)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == id);

        if (user == null)
        {
            return false;
        }

        var salt = BCrypt.Net.BCrypt.GenerateSalt();
        var hash = BCrypt.Net.BCrypt.HashPassword(userPassword, salt);

        user.PasswordHash = hash;
        user.PasswordSalt = salt;

        _context.SaveChanges();

        return true;
    }

    public override List<GetUserDto>? GetAll(int schoolId)
    {
        var records = _context.Users.ToList();
        return records.Count == 0 ? null : _mapper.Map<List<GetUserDto>>(records);
    }
}
