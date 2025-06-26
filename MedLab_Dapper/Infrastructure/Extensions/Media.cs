namespace MedLab_Dapper.Infrastructure.Extensions;

public static class Media
{
    public static string UploadImage(IFormFile file)
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var folder = Path.Combine(currentDirectory, "wwwroot/images");
        if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

        if (extension != ".png" && extension != ".jpg" && extension != ".jpeg")
            throw new ArgumentOutOfRangeException("The media must be in image's format");
        var imageName = String.Concat(Guid.NewGuid().ToString(), extension);
        var imagePath = Path.Combine(folder, imageName);
        using var stream = new FileStream(imagePath, FileMode.Create);
        file.CopyTo(stream);
        return string.Concat("/images/", imageName);
    }
}
