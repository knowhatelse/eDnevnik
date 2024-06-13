namespace eDnevnik___backend.Interfaces
{
    public interface IBaseUserService<TGetDto, TCreateDto, TUpdateDto> 
        : IBaseCRUDService<TGetDto, TCreateDto, TUpdateDto>
    {
        TGetDto? GetByUsername(string username);
    }
}
