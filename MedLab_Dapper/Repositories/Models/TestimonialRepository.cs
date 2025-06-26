using Dapper;
using MedLab_Dapper.Dtos.TestimonialDtos;
using MedLab_Dapper.Infrastructure.Extensions;
using MedLab_Dapper.Repositories.Context;
using MedLab_Dapper.Repositories.Contracts;

namespace MedLab_Dapper.Repositories.Models;

public class TestimonialRepository : ITestimonialRepository
{
    private readonly DapperDbContext _context;
    public TestimonialRepository(DapperDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ResultTestimonialDto>> GetAllAsync()
    {
        var query = "SELECT * FROM Testimonials";
        return await _context.CreateConnection().QueryAsync<ResultTestimonialDto>(query);
    }

    public async Task<UpdateTestimonialDto> GetByIdAsync(int id)
    {
        var query = "SELECT * FROM Testimonials WHERE Id = @Id";

        var parameter = new DynamicParameters();
        parameter.Add("Id", id);
        return await _context.CreateConnection().QueryFirstOrDefaultAsync<UpdateTestimonialDto>(query, parameter);
    }
    public async Task CreateAsync(CreateTestimonialDto testimonial)
    {
        testimonial.ImageUrl = Media.UploadImage(testimonial.ImageFile);
        var query = "INSERT INTO Testimonials (FullName, Title, Rating,Comment,ImageUrl) VALUES (@FullName, @Title, @Rating, @Comment, @ImageUrl)";
        var parameters = new DynamicParameters(testimonial);
        parameters.Add("ImageUrl", testimonial.ImageUrl); // Handle optional ImageUrl
        parameters.Add("Rating", testimonial.Rating > 0 ? testimonial.Rating : (object)DBNull.Value);
        parameters.Add("Comment", testimonial.Comment);
        parameters.Add("FullName", testimonial.FullName);
        parameters.Add("Title", testimonial.Title);
        // Handle optional Rating
        await _context.CreateConnection().ExecuteAsync(query, testimonial);
    }

    public async Task UpdateAsync(UpdateTestimonialDto testimonial)
    {
        if (testimonial.ImageFile != null)
        {
            testimonial.ImageUrl = Media.UploadImage(testimonial.ImageFile);
        }
        else
        {
            // If no new image is provided, keep the existing ImageUrl
            var existingTestimonial = await GetByIdAsync(testimonial.Id);
            testimonial.ImageUrl = existingTestimonial?.ImageUrl;
        }
        var query = "UPDATE Testimonials SET FullName = @FullName, Title = @Title, Comment = @Comment, Rating=@Rating, ImageUrl=@ImageUrl WHERE Id = @Id";
        await _context.CreateConnection().ExecuteAsync(query, testimonial);
    }
    
    public async Task DeleteAsync(int id)
    {
        var query = "DELETE FROM Testimonials WHERE Id = @Id";
        var parameter = new DynamicParameters();
        parameter.Add("Id", id);
        await _context.CreateConnection().ExecuteAsync(query, parameter);
    }   
}
