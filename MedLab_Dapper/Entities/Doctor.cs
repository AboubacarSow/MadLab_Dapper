namespace MedLab_Dapper.Entities;

public class Doctor
{
    public int DoctorId {  get; set; }  
    public string FullName { get; set; }    
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public int DescriptionId { get; set; }  
    public ICollection<SocialMedia> SocialMedias { get; set; }
}
