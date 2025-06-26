namespace MedLab_Dapper.Dtos.TestimonialDtos;

public class UpdateTestimonialDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public string Comment { get; set; }
    public FormFile? ImageFile { get; set; }
}
