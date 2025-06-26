namespace MedLab_Dapper.Dtos.GalleryDtos;

public class GalleryDto
{
    public int GalleryId { get; set; }
    public string? ImageUrl { get; set; }
    public IFormFile ImageFile { get; set; }    
}
