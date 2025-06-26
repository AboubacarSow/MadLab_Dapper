using MedLab_Dapper.Dtos.SocialMediaDtos;

namespace MedLab_Dapper.Repositories.Contracts;

public interface ISocialMediaRepository
{
    Task<IEnumerable<ResultSocialMediaDto>> GetAllAsync();
    Task<UpdateSocialMediaDto> GetByIdAsync(int id);
    Task CreateAsync(CreateSocialMediaDto socialMedia);
    Task UpdateAsync(UpdateSocialMediaDto socialMedia);
    Task DeleteAsync(int id);
}

