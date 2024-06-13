using AutoMapper;
using eDnevnik___backend.Data;
using eDnevnik___backend.DTOs.ContactInformationDto;
using eDnevnik___backend.Entities;
using eDnevnik___backend.Interfaces;

namespace eDnevnik___backend.Services;

public class ContactInformationService(eDnevnikDbContext context, IMapper mapper) 
    : BaseCRUDService<ContactInformation, GetContactInformationDto, CreateContactInformationDto, UpdateContactInformationDto>(context, mapper),
    IContactInformationService
{
    private readonly eDnevnikDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    // ! Da li treba override-ati metodu "GetById" tako da vraća po ID-u user-a,
    // ! ili ostaviti da vraća entity po ID-u i eventualno implementirati "GetByUserId" metodu?
    // ? Ili na frontend-u "forsirati" tokom dodavanja user-a i dodavanje kontakt informacija
    // ? tako da uvijek ID od entity-a odgovara ID-u usera?

    public override object? GetById(int id)
    {
        var record = _context.ContactInformations.FirstOrDefault(x => x.UserId == id);

        if (record == null)
        {
            return null;
        }

        return _mapper.Map<GetContactInformationDto>(record);
    }
}