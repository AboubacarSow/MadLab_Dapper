using Dapper;
using MedLab_Dapper.Dtos.MessageDtos;
using MedLab_Dapper.Repositories.Context;
using MedLab_Dapper.Repositories.Contracts;

namespace MedLab_Dapper.Repositories.Models;
public class MessageRepository : IMessageRepository
{
    private readonly DapperDbContext _context;

    public MessageRepository(DapperDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ResultMessageDto>> GetAllAsync()
    {
        var query = "SELECT * FROM Messages";
        return await _context.CreateConnection().QueryAsync<ResultMessageDto>(query);
    }

    public async Task CreateAsync(CreateMessageDto message)
    {
        var date= DateTime.UtcNow;
        var query = @"
            INSERT INTO Messages (UserName, Email, Subject, Body,CreatedAt)
            VALUES (@Name, @Email, @Subject, @Message, @CreatedAt)";
        var parameters = new DynamicParameters();
        parameters.Add("Name", message.Name);
        parameters.Add("Email", message.Email);
        parameters.Add("Subject", message.Subject);
        parameters.Add("Message", message.Body);
        parameters.Add("CreatedAt", date);
        await _context.CreateConnection().ExecuteAsync(query, parameters);
    }

    public async Task DeleteAsync(int id)
    {
        var query = @"
            DELETE FROM Messages
            WHERE Id = @Id";
        var parameters = new DynamicParameters();
        parameters.Add("Id", id);
        await _context.CreateConnection().ExecuteAsync(query, parameters);
    }
}