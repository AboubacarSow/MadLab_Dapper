using MedLab_Dapper.Dtos.FrequentlyQuestionDtos;
using MedLab_Dapper.Dtos.GalleryDtos;

namespace MedLab_Dapper.Repositories.Contracts;

public interface IFrequentlyQuestionRepository
{
    Task<IEnumerable<ResultFrequentlyQuestion>> GetAllAsync();
    Task<UpdateFrequentlyQuestion> GetByIdAsync(int id);
    Task CreateAsync(CreateFrequentlyQuestion question);
    Task UpdateAsync(UpdateFrequentlyQuestion question);
    Task DeleteAsync(int id);
}
