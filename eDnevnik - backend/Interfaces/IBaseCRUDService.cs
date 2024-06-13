namespace eDnevnik___backend.Interfaces;

public interface IBaseCRUDService<TGetDto, in TCreateDto, in TUpdateDto>
{
    public List<TGetDto>? GetAll(int schoolId);
    public object? GetById(int id);
    public TGetDto Add(TCreateDto addDto);
    public object? Update(int id, TUpdateDto updateDto);
    public bool Delete(int id);
}