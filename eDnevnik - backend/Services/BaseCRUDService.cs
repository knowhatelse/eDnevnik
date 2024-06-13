using AutoMapper;
using eDnevnik___backend.Data;
using eDnevnik___backend.Interfaces;

namespace eDnevnik___backend.Services;

public class BaseCRUDService<TEntity, TGetDto, TCreateDto, TUpdateDto>(eDnevnikDbContext context, IMapper mapper)
    : IBaseCRUDService<TGetDto, TCreateDto, TUpdateDto> where TEntity : class
{
    private eDnevnikDbContext _context = context;
    private IMapper _mapper = mapper;

    public virtual List<TGetDto>? GetAll(int schoolId)
    {
        var records = _context.Set<TEntity>().ToList();
        return records.Count == 0 ? null : _mapper.Map<List<TGetDto>>(records);
    }

    public virtual object? GetById(int id)
    {
        var record = _context.Set<TEntity>().Find(id);

        if (record == null)
        {
            return null;
        }

        return _mapper.Map<TGetDto>(record);
    }

    public virtual TGetDto Add(TCreateDto addDto)
    {
        var newRecord = _mapper.Map<TEntity>(addDto);

        _context.Set<TEntity>().Add(newRecord!);
        _context.SaveChanges();

        return _mapper.Map<TGetDto>(newRecord);
    }

    public virtual object? Update(int id, TUpdateDto updateDto)
    {
        var existingRecord = _context.Set<TEntity>().Find(id);

        if (existingRecord == null)
        {
            return null;
        }

        existingRecord = _mapper.Map(updateDto, existingRecord);
        _context.SaveChanges();

        return _mapper.Map<TGetDto>(existingRecord);
    }

    public virtual bool Delete(int id)
    {
        var record = _context.Set<TEntity>().Find(id);

        if (record == null)
        {
            return false;
        }

        _context.Set<TEntity>().Remove(record);
        _context.SaveChanges();

        return true;
    }
}