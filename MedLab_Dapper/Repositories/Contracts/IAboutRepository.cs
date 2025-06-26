using MedLab_Dapper.Dtos.AboutDtos;

namespace MedLab_Dapper.Repositories.Contracts;

public interface IAboutRepository
{
    Task<IEnumerable<ResultAboutDto>> GetAllAsync();
    Task<IEnumerable<ResultAboutWithItems>> GetAllWithItemsAsync();
    Task<UpdateAboutDto> GetByIdAsync(int id);
    Task CreateAsync(CreateAboutDto about);
    Task UpdateAsync(UpdateAboutDto about);
    Task DeleteAsync(int id);
}
