using AutoMapper;
using eDnevnik___backend.Data;
using eDnevnik___backend.DTOs.ClassDto;
using eDnevnik___backend.Entities;
using eDnevnik___backend.Interfaces;

namespace eDnevnik___backend.Services
{
    public class ClassService(eDnevnikDbContext context, IMapper mapper)
        : BaseCRUDService<Class, GetClassDto, CreateClassDto, UpdateClassDto>(context, mapper), IClassService
    {
        private readonly eDnevnikDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public override List<GetClassDto>? GetAll(int schoolId)
        {
            var records = _context.Classes.ToList();
            return records.Count == 0 ? null : _mapper.Map<List<GetClassDto>>(records);
        }
    }
}
