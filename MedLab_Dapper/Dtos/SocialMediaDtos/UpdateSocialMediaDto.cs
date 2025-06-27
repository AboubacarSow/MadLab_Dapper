namespace MedLab_Dapper.Dtos.SocialMediaDtos;

public class UpdateSocialMediaDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Icon { get; set; }
    public string Link { get; set; }
    public int DoctorId {  get; set; }
}