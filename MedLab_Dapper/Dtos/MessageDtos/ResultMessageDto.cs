namespace MedLab_Dapper.Dtos.MessageDtos;

public class ResultMessageDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public DateTime CreatedAt { get; set; }
}
