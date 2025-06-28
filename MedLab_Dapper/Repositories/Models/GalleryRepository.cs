using Dapper;
using MedLab_Dapper.Dtos.GalleryDtos;
using MedLab_Dapper.Infrastructure.Extensions;
using MedLab_Dapper.Repositories.Context;
using MedLab_Dapper.Repositories.Contracts;
using Microsoft.VisualBasic;

namespace MedLab_Dapper.Repositories.Models;

public class GalleryRepository : IGalleryRepository
{
    private DapperDbContext _context;

    public GalleryRepository(DapperDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(CreateGalleryDto gallery)
    {
        var imageUrl=Media.UploadImage(gallery.ImageFile);
        var query = "insert into Galleries(ImageUrl) values(@ImageUrl)";
        var parameter = new DynamicParameters();
        parameter.Add("@ImageUrl", imageUrl);
        var connection=_context.CreateConnection(); 
       await connection.ExecuteAsync(query, parameter);
    }

    public async Task DeleteAsync(int id)
    {
        var query = "delete from Galleries where GalleryId=@id";
        var parameter = new DynamicParameters();
        parameter.Add("@id", id);
        var connection=_context.CreateConnection();
        await connection.ExecuteAsync(query, parameter);
    }

    public Task<IEnumerable<ResultGalleryDto>> GetAllAsync()
    {
        var query = "select * from Galleries";
        var connection= _context.CreateConnection();    
        return connection.QueryAsync<ResultGalleryDto>(query);
    }

    public async Task<GalleryDto> GetByIdAsync(int id)
    {
        var query = "select * from Galleries where GalleryId=@id";
        var parameter= new DynamicParameters();
        parameter.Add("@id", id);

        var connection=_context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<GalleryDto>(query, parameter);
    }

    public async Task UpdateAsync(GalleryDto gallery)
    {
        
        var query = "update Galleries set ImageUrl=@ImageUrl where GalleryId=@GalleryId";
        var parameter=new DynamicParameters();
        parameter.Add("@GalleryId", gallery.GalleryId);
        parameter.Add("@ImageUrl",gallery.ImageUrl);
        var connection=_context.CreateConnection(); 
        await connection.ExecuteAsync(query, parameter);
    }
}



