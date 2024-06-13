using eDnevnik___backend.DTOs.ParentDto;
using eDnevnik___backend.DTOs.UserDto;

namespace eDnevnik___backend.Interfaces;

public interface IParentService : IBaseUserService<GetParentDto, CreateParentDto, UpdateParentDto>
{
    
}