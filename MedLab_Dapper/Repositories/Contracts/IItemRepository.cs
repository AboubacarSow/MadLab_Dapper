using MedLab_Dapper.Dtos.ItemDtos;

namespace MedLab_Dapper.Repositories.Contracts;
public interface IItemRepository
{
    Task<IEnumerable<ResultItemDto>> GetAllAsync();
    Task<UpdateItemDto> GetByIdAsync(int id);
    Task CreateAsync(CreateItemDto item);
    Task UpdateAsync(UpdateItemDto item);
    Task DeleteAsync(int id);
}