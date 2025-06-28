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

    public async Task<IEnumerable<GetSocialMediaWithDoctor>> GetAllAsync()
    {
        var query = "SELECT Id,Name,Icon,Link,FullName FROM SocialMedias as S inner join Doctors as D on S.DoctorId=D.DoctorId";
        return await _dbConnection.CreateConnection().QueryAsync<GetSocialMediaWithDoctor>(query);
    }

    public async Task<UpdateSocialMediaDto> GetByIdAsync(int id)
    {
        var query = "SELECT * FROM SocialMedias WHERE Id = @Id";
        return await _dbConnection.CreateConnection().QueryFirstOrDefaultAsync<UpdateSocialMediaDto>(query, new { Id = id });
    }

    public async Task CreateAsync(CreateSocialMediaDto socialMedia)
    {
        var query = "INSERT INTO SocialMedias (Name, Icon, Link, DoctorId) VALUES (@Name, @Icon, @Link,@DoctorId)";
        await _dbConnection.CreateConnection().ExecuteAsync(query, socialMedia);
    }

    public async Task UpdateAsync(UpdateSocialMediaDto socialMedia)
    {
        var query = "UPDATE SocialMedias SET Name = @Name, Icon = @Icon, Link = @Link, DoctorId=@DoctorId WHERE Id = @Id";
        await _dbConnection.CreateConnection().ExecuteAsync(query, socialMedia);
    }

    public async Task DeleteAsync(int id)
    {
        var query = "DELETE FROM SocialMedia WHERE Id = @Id";
        await _dbConnection.CreateConnection().ExecuteAsync(query, new { Id = id });
    }
}
