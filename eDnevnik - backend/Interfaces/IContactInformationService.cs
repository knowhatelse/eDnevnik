using eDnevnik___backend.DTOs.ContactInformationDto;

namespace eDnevnik___backend.Interfaces;

public interface IContactInformationService 
    : IBaseCRUDService<GetContactInformationDto, CreateContactInformationDto, UpdateContactInformationDto>
{
    
}