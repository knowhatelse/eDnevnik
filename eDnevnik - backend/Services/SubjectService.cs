using AutoMapper;
using eDnevnik___backend.Data;
using eDnevnik___backend.DTOs.SubjectDto;
using eDnevnik___backend.Entities;
using eDnevnik___backend.Interfaces;

namespace eDnevnik___backend.Services
{
    public class SubjectService(eDnevnikDbContext context, IMapper mapper)
        : BaseCRUDService<Subject, GetSubjectDto, CreateSubjectDto, UpdateSubjectDto>(context, mapper), ISubjectService
    {
        private readonly eDnevnikDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public override List<GetSubjectDto>? GetAll(int schoolId)
        {
            var records = _context.Subjects.ToList();
            return records.Count == 0 ? null : _mapper.Map<List<GetSubjectDto>>(records);
        }
    }
}
