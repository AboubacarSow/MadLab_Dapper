using Dapper;
using MedLab_Dapper.Dtos.ServiceDtos;
using MedLab_Dapper.Repositories.Context;
using MedLab_Dapper.Repositories.Contracts;

namespace MedLab_Dapper.Repositories.Models;

public class ServiceRepository : IServiceRepository
{
    private readonly DapperDbContext _context;

    public ServiceRepository(DapperDbContext context)
    {
        _context = context;
    }

    public Task<IEnumerable<ResultServiceDto>> GetAllAsync()
    {
        var query = @"
            SELECT * FROM Services";
        return _context.CreateConnection().QueryAsync<ResultServiceDto>(query);
    }

    public Task<UpdateServiceDto> GetByIdAsync(int id)
    {
        var query = @"
            SELECT * FROM Services
            WHERE Id = @Id";
        var parameters = new DynamicParameters();
        parameters.Add("Id", id);
        return _context.CreateConnection().QueryFirstOrDefaultAsync<UpdateServiceDto>(query, parameters);
    }

    public async Task CreateAsync(CreateServiceDto service)
    {
        var query = @"
            INSERT INTO Services (Name, Description, Icon)
            VALUES (@Name, @Description, @Icon)";
        var parameters = new DynamicParameters(service);
        await _context.CreateConnection().ExecuteAsync(query, parameters);
    }

    public Task UpdateAsync(UpdateServiceDto service)
    {
        var query = @"
            UPDATE Services
            SET Name = @Name, Description = @Description, Icon = @Icon
            WHERE Id = @Id";
        var parameters = new DynamicParameters(service);
        return _context.CreateConnection().ExecuteAsync(query, parameters);
    }

    public async Task DeleteAsync(int id)
    {
        var query = @"
            DELETE FROM Services
            WHERE Id = @Id";
        var parameters = new DynamicParameters();
        parameters.Add("Id", id);
        await _context.CreateConnection().ExecuteAsync(query, parameters);
    }
}