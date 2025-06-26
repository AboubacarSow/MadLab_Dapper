using MedLab_Dapper.Dtos.ContactDtos;
using MedLab_Dapper.Dtos.MessageDtos;
using MedLab_Dapper.Dtos.TestimonialDtos;
using System.Threading.Tasks;

namespace MedLab_Dapper.Repositories.Contracts;

public interface ITestimonialRepository
{
    Task<IEnumerable<ResultTestimonialDto>> GetAllAsync();
    Task<UpdateTestimonialDto> GetByIdAsync(int id);
    Task CreateAsync(CreateTestimonialDto contact);
    Task UpdateAsync(UpdateTestimonialDto contact);
    Task DeleteAsync(int id);
}
