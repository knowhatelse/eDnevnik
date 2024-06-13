using eDnevnik___backend.DTOs.UserDto;
using eDnevnik___backend.Interfaces;

namespace eDnevnik___backend;

public interface IUserService : IBaseUserService<GetUserDto, CreateUserDto, UpdateUserDto>
{
    GetUserPasswordDto? GetUserPassword(int id);
    bool UpdateUserPassword(int id, string userPassword);
}
