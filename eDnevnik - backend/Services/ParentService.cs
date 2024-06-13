using AutoMapper;
using eDnevnik___backend.Data;
using eDnevnik___backend.DTOs.ParentDto;
using eDnevnik___backend.Entities;
using eDnevnik___backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eDnevnik___backend.Services
{
    public class ParentService(eDnevnikDbContext context, IMapper mapper) 
        : BaseUserService<Parent, GetParentDto, CreateParentDto, UpdateParentDto>(context, mapper), IParentService
    {
        private readonly eDnevnikDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public override object? GetById(int id)
        {
            var parent = _context.Parents.Include(p => p.Students).FirstOrDefault(p => p.Id == id);
            return _mapper.Map<GetParentDto>(parent);
        }
    }
}
