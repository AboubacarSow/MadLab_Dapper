namespace MedLab_Dapper.Dtos.ItemDtos;
public class UpdateItemDto
{
    public int ItemId { get; set; }
    public string Icon { get; set; }
    public string Description { get; set; }    
    public int AboutId { get; set; }
}