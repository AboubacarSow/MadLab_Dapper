using Microsoft.Build.ObjectModelRemoting;

namespace MedLab_Dapper.Dtos.ItemDtos;

public class ResultItemDto
{
     public int ItemId { get; set; }
    public string Icon { get; set; }
    public string Description { get; set; }    
    public string Title {  get; set; }
    public int AboutId { get; set; }
    
}