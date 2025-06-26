using Dapper;
using MedLab_Dapper.Dtos.AboutDtos;
using MedLab_Dapper.Repositories.Context;
using MedLab_Dapper.Repositories.Contracts;

namespace MedLab_Dapper.Repositories.Models;

public class AboutRepository : IAboutRepository
{
    public readonly DapperDbContext _context;

    public AboutRepository(DapperDbContext context) => _context = context;

    public async Task CreateAsync(CreateAboutDto about)
    {
        var query = "insert into Abouts(ImageUrl,VideoUrl,Description)" + 
            "values (@ImageUrl,@ViedoUrl,@Description)";
        var parameters = new DynamicParameters();
        parameters.Add("@ImageUrl",about.ImageUrl); 
        parameters.Add("@VideoUrl",about.VideoUrl);
        parameters.Add("@Description",about.Description);   
        var connection= _context.CreateConnection();
        await connection.ExecuteAsync(query,parameters);
    }

    public async Task DeleteAsync(int id)
    {
        await DeleteItems(id);
        var query = "delete from Abouts where AboutId=@id";
        var parameters = new DynamicParameters();   
        parameters.Add("@id",id);
        var connection= _context.CreateConnection();
        await connection.ExecuteAsync(query,parameters);
    }
    private async Task DeleteItems(int id)
    {
        var queryItems = "select * from Items where AboutId=@id";
        var parameters = new DynamicParameters();
        parameters.Add("@id", id);
        var connection = _context.CreateConnection();
        await connection.ExecuteAsync(queryItems, parameters);
    }
    public async Task<IEnumerable<ResultAboutDto>> GetAllAsync()
    {
        var query = "select AboutId,ImageUrl,Description from Abouts";
        var connection=_context.CreateConnection();
        return await connection.QueryAsync<ResultAboutDto>(query);
    }

    public async Task<IEnumerable<ResultAboutWithItems>> GetAllWithItemsAsync()
    {
        var query = "select * from Abouts inner join Items on Abouts.AboutId=Items.AboutId";
        var connection=_context.CreateConnection(); 
        return await connection.QueryAsync<ResultAboutWithItems>(query);
    }

    public async Task<UpdateAboutDto> GetByIdAsync(int id)
    {
        var query = "select * from Abouts where AboutId=@id";
        var parameters= new DynamicParameters();
        parameters.Add("@id", id);
        var connection= _context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<UpdateAboutDto>(query, parameters);
    }

    public async Task UpdateAsync(UpdateAboutDto about)
    {
        var query = "update Abouts set ImageUrl=@ImageUrl,VideoUrl=@VideoUrl,Description=@Description," +
            "where AboutId=@AboutId";
        var parameters=new DynamicParameters();
        parameters.Add("@AboutId",about.AboutId);
        parameters.Add("@ImageUrl",about.ImageUrl);
        parameters.Add("@VideoUrl",about.VideoUrl);
        parameters.Add("@Description",about.Description);
        var connection = _context.CreateConnection();
        await connection.ExecuteAsync(query, parameters);   
        
    }
}
