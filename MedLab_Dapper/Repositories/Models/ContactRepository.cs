using Dapper;
using MedLab_Dapper.Dtos.ContactDtos;
using MedLab_Dapper.Repositories.Context;
using MedLab_Dapper.Repositories.Contracts;

namespace MedLab_Dapper.Repositories.Models;

public class ContactRepository : IContactRepository
{
    private readonly DapperDbContext _dbContext;
    public ContactRepository(DapperDbContext dbContext) => _dbContext = dbContext;
    public async Task CreateAsync(CreateContactDto contact)
    {
        var query = "insert into Contacts(PhoneNumber,Email,Location,MapUrl) values(@PhoneNumber,@Email,@Location,@MapUrl)";
        var parameters = new DynamicParameters(contact);
        var connection= _dbContext.CreateConnection();  
        await connection.ExecuteAsync(query, parameters);
    }

    public async Task DeleteAsync(int id)
    {
        var query = "delete from Contacts where ContactId=@id";
        var parameter = new DynamicParameters();
        parameter.Add("@id", id);
        var connection=_dbContext.CreateConnection();
        await connection.ExecuteAsync(query, parameter);
    }

    public async Task<IEnumerable<ResultContactDto>> GetAllAsync()
    {
        var query = "select * from Contacts";
        var connection = _dbContext.CreateConnection();
        return await connection.QueryAsync<ResultContactDto>(query);
    }

    public async Task<UpdateContactDto> GetByIdAsync(int id)
    {
        var query = "select * from Contacts where ContactId=@id";
        var parameter= new DynamicParameters();
        parameter.Add("@id", id);
        var connection = _dbContext.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<UpdateContactDto>(query, parameter);
    }

    public async Task UpdateAsync(UpdateContactDto contact)
    {
        var query = "update Contacts set PhoneNumber=@PhoneNumber,Email=@Email,Location=@Location,MapUrl=@MapUrl" +
            "where ContactId=@ContactId";
        var parameter = new DynamicParameters(contact);
        var connection = _dbContext.CreateConnection();
        await connection.ExecuteAsync(query,parameter);
    }
}
