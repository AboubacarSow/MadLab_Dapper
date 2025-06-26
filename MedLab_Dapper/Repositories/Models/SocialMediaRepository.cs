using Dapper;
using MedLab_Dapper.Dtos.SocialMediaDtos;
using MedLab_Dapper.Repositories.Context;
using MedLab_Dapper.Repositories.Contracts;

namespace MedLab_Dapper.Repositories.Models;
public class SocialMediaRepository : ISocialMediaRepository
{
    private readonly DapperDbContext _dbConnection;

    public SocialMediaRepository(DapperDbContext dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<ResultSocialMediaDto>> GetAllAsync()
    {
        var query = "SELECT * FROM SocialMedias";
        return await _dbConnection.CreateConnection().QueryAsync<ResultSocialMediaDto>(query);
    }

    public async Task<UpdateSocialMediaDto> GetByIdAsync(int id)
    {
        var query = "SELECT * FROM SocialMedias WHERE Id = @Id";
        return await _dbConnection.CreateConnection().QueryFirstOrDefaultAsync<UpdateSocialMediaDto>(query, new { Id = id });
    }

    public async Task CreateAsync(CreateSocialMediaDto socialMedia)
    {
        var query = "INSERT INTO SocialMedias (Name, Icon, Link) VALUES (@Name, @Icon, @Link)";
        await _dbConnection.CreateConnection().ExecuteAsync(query, socialMedia);
    }

    public async Task UpdateAsync(UpdateSocialMediaDto socialMedia)
    {
        var query = "UPDATE SocialMedias SET Name = @Name, Icon = @Icon, Link = @Link WHERE Id = @Id";
        await _dbConnection.CreateConnection().ExecuteAsync(query, socialMedia);
    }

    public async Task DeleteAsync(int id)
    {
        var query = "DELETE FROM SocialMedia WHERE Id = @Id";
        await _dbConnection.CreateConnection().ExecuteAsync(query, new { Id = id });
    }
}
