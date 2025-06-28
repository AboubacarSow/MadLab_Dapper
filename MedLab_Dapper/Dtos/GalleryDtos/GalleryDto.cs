namespace MedLab_Dapper.Dtos.GalleryDtos;

public class CreateGalleryDto
{
    public int GalleryId { get; set; }
    public IFormFile ImageFile { get; set; }
}
public class GalleryDto {
    public int GalleryId { get; set; }
    public IFormFile? ImageFile { get;set; }
    public string ImageUrl {  get; set; }
}

