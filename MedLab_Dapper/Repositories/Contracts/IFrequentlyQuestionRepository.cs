using MedLab_Dapper.Dtos.FrequentlyQuestionDtos;
using MedLab_Dapper.Dtos.GalleryDtos;

namespace MedLab_Dapper.Repositories.Contracts;

public interface IFrequentlyQuestionRepository
{
    Task<IEnumerable<ResultFrequentlyQuestion>> GetAllAsync();
    Task<UpdateFrequentlyQuestionDto> GetByIdAsync(int id);
    Task CreateAsync(CreateFrequentlyQuestionDto question);
    Task UpdateAsync(UpdateFrequentlyQuestionDto question);
    Task DeleteAsync(int id);
}
