namespace MedLab_Dapper.Dtos.AboutDtos;

public class CreateAboutDto
{
    public string VideoUrl { get; set; }
    public string Description { get; set; }
    public IFormFile ImageFile { get; set; }
}
