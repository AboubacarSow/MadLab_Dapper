namespace MedLab_Dapper.Dtos.AboutDtos;

public class UpdateAboutDto :AboutDto
{
    public int AboutId { get; set; }
    public IFormFile ImageFile { get; set; }    
}
