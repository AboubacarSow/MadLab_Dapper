using System.Security.Cryptography.Pkcs;

namespace MedLab_Dapper.Entities;

public class Testimonial
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Title {  get; set; }
    public string ImageUrl {  get; set; }
    public string Comment {  get; set; }
}
