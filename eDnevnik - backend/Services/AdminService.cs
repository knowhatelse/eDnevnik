using AutoMapper;
using eDnevnik___backend.Data;
using eDnevnik___backend.DTOs.AdminDto;
using eDnevnik___backend.Entities;
using eDnevnik___backend.Interfaces;

namespace eDnevnik___backend.Services
{
    public class AdminService(eDnevnikDbContext context, IMapper mapper) 
        : BaseUserService<Admin, GetAdminDto, CreateAdminDto, UpdateAdminDto>(context, mapper), IAdminService
    {
    }
}
    

