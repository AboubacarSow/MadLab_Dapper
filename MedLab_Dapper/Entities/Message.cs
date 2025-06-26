namespace MedLab_Dapper.Entities;

public class Message
{
    public int MessageId { get; set; } 
    public string UserName {  get; set; }   
    public string Email {  get; set; }
    public string Subject {  get; set; }    
    public string Body { get; set; }
}
