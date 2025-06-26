namespace MedLab_Dapper.Entities;

public class About
{
    public int AboutId { get; set; } 
    public string ImageUrl {  get; set; }   
    public string VideoUrl {  get; set; }   
    public string Description {  get; set; }    
    public ICollection<Item> Items { get; set; }   
}
