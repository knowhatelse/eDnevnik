using eDnevnik___backend.DTOs.AdminDto;
using eDnevnik___backend.DTOs.UserDto;

namespace eDnevnik___backend.Interfaces;

public interface IAdminService: IBaseUserService<GetAdminDto, CreateAdminDto, UpdateAdminDto>
{
    
}