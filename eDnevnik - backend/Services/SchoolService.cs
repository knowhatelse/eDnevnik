using AutoMapper;
using eDnevnik___backend.Data;
using eDnevnik___backend.DTOs.SchoolDto;
using eDnevnik___backend.Entities;
using eDnevnik___backend.Interfaces;

namespace eDnevnik___backend.Services;

public class SchoolService(eDnevnikDbContext context, IMapper mapper)
    : BaseCRUDService<School, GetSchoolDto, CreateSchoolDto, UpdateSchoolDto>(context, mapper), ISchoolService
{

}