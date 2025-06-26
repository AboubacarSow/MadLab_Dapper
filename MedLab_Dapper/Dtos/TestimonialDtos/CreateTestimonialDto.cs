namespace MedLab_Dapper.Dtos.TestimonialDtos;

public class CreateTestimonialDto
{
    public string FullName { get; set; }
    public string Title { get; set; }
    public string? ImageUrl { get; set; }
    public int Rating { get; set; }
    public FormFile ImageFile { get; set; }
    public string Comment { get; set; }
}
