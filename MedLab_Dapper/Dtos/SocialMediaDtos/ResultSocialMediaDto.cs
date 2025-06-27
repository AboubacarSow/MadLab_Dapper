namespace MedLab_Dapper.Dtos.SocialMediaDtos;

public class ResultSocialMediaDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Icon { get; set; }
    public string Link { get; set; }
    public int DoctorId { get; set; }
}

public class GetSocialMediaWithDoctor {

    public int Id { get; set; }
    public string Name { get; set; }
    public string Icon { get; set; }
    public string Link { get; set; }
    public string DoctorName { get; set; }
}
