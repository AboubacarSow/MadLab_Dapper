using MedLab_Dapper.Dtos.MessageDtos;

namespace MedLab_Dapper.Repositories.Contracts;

public interface IMessageRepository
{
    Task<IEnumerable<ResultMessageDto>> GetAllAsync();
    Task CreateAsync(CreateMessageDto message);
    Task DeleteAsync(int id);
}
