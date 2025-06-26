namespace MedLab_Dapper.Dtos.AppointmentDtos;   
public class ResultAppointmentDto
{
    public int Id { get; set; }
    public string PatientName { get; set; }
    public string DoctorName { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string Status { get; set; }
    public string Notes { get; set; }
}