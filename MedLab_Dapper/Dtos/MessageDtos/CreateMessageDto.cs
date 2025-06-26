namespace MedLab_Dapper.Dtos.MessageDtos;

public class CreateMessageDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}