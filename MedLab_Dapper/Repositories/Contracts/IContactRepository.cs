using MedLab_Dapper.Dtos.ContactDtos;

namespace MedLab_Dapper.Repositories.Contracts;

public interface IContactRepository
{
    Task<IEnumerable<ResultContactDto>> GetAllAsync();
    Task<UpdateContactDto> GetByIdAsync(int id);
    Task CreateAsync(CreateContactDto contact);
    Task UpdateAsync(UpdateContactDto contact);
    Task DeleteAsync(int id);
}
