using MedLab_Dapper.Dtos.GalleryDtos;

namespace MedLab_Dapper.Repositories.Contracts;

public interface IGalleryRepository
{
    Task<IEnumerable<ResultGalleryDto>> GetAllAsync();
    Task<GalleryDto> GetByIdAsync(int id);
    Task CreateAsync(CreateGalleryDto gallery);
    Task UpdateAsync(GalleryDto gallery);
    Task DeleteAsync(int id);
}
