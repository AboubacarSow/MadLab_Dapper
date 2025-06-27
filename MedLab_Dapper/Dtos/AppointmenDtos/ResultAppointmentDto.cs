namespace MedLab_Dapper.Dtos.AppointmentDtos;   
public class ResultAppointmentDto
{
    public int Id { get; set; }
    public string PatientName { get; set; }
    public string Email { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string DepartmentName { get; set; }
    public string DoctorName { get; set; }
    public string? Message { get; set; }

}