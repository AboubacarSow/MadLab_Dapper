namespace MedLab_Dapper.Repositories.Models;

using Dapper;
using MedLab_Dapper.Dtos.ItemDtos;
using MedLab_Dapper.Repositories.Context;
using MedLab_Dapper.Repositories.Contracts;

public class ItemRepository : IItemRepository
{
    private readonly DapperDbContext _context   ;

    public ItemRepository(DapperDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ResultItemDto>> GetAllAsync()
    {
        var query = "SELECT * FROM Items";
        return await _context.CreateConnection().QueryAsync<ResultItemDto>(query);
    }

    public async Task<UpdateItemDto> GetByIdAsync(int id)
    {
        var query = "SELECT * FROM Items WHERE ItemId = @Id";
        var parameter= new DynamicParameters();
        parameter.Add("Id", id);
        // Using QueryFirstOrDefaultAsync to return a single item or null if not found
        return await _context.CreateConnection().QueryFirstOrDefaultAsync<UpdateItemDto>(query, parameter);
    }

    public async Task CreateAsync(CreateItemDto item)
    {
        var query = "INSERT INTO Items (Icon, Description, AboutId) VALUES (@Icon, @Description, @AboutId)";
        var parameters = new DynamicParameters(item);
        await _context.CreateConnection().ExecuteAsync(query, parameters);
    }

    public async Task UpdateAsync(UpdateItemDto item)
    {
        var query = "UPDATE Items SET Icon = @Icon, Description = @Description, AboutId = @AboutId WHERE ItemId = @ItemId";
        var parameters = new DynamicParameters(item);
        await _context.CreateConnection().ExecuteAsync(query, parameters);
    }

    public async Task DeleteAsync(int id)
    {
        var query = "DELETE FROM Items WHERE ItemId = @Id";
        var parameter=new DynamicParameters();
        parameter.Add("Id", id);    
        await _context.CreateConnection().ExecuteAsync(query, parameter);
    }
}