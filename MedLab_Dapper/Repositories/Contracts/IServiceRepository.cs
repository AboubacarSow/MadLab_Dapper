using MedLab_Dapper.Dtos.ServiceDtos;

namespace MedLab_Dapper.Repositories.Contracts;
public interface IServiceRepository
{
    Task<IEnumerable<ResultServiceDto>> GetAllAsync();
    Task<UpdateServiceDto> GetByIdAsync(int id);
    Task CreateAsync(CreateServiceDto service);
    Task UpdateAsync(UpdateServiceDto service);
    Task DeleteAsync(int id);
}

