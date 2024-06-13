using AutoMapper;
using eDnevnik___backend.Data;
using eDnevnik___backend.DTOs.UserDto;
using eDnevnik___backend.Entities;
using eDnevnik___backend.Interfaces;

namespace eDnevnik___backend.Services;

public class BaseUserService<TEntity, TGetDto, TCreateDto, TUpdateDto>(eDnevnikDbContext context, IMapper mapper)
    : BaseCRUDService<TEntity, TGetDto, TCreateDto, TUpdateDto>(context, mapper), IBaseUserService<TGetDto, TCreateDto, TUpdateDto> 
    where TEntity : User where TCreateDto : CreateUserDto
{
    private readonly eDnevnikDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public virtual TGetDto? GetByUsername(string username)
    {
        return _mapper.Map<TGetDto>(_context.Set<TEntity>().FirstOrDefault(x => x.Username == username));
    }

    public override TGetDto Add(TCreateDto addDto)
    {
        var newRecord = _mapper.Map<TEntity>(addDto);

        var salt = BCrypt.Net.BCrypt.GenerateSalt();
        var hash = BCrypt.Net.BCrypt.HashPassword(addDto.Password, salt);

        var role = RoleManager<TEntity>.GetRole(newRecord);

        newRecord.PasswordSalt = salt;
        newRecord.PasswordHash = hash;
        newRecord.Role = role;

        _context.Set<TEntity>().Add(newRecord);
        _context.SaveChanges();

        return _mapper.Map<TGetDto>(newRecord);
    }
}