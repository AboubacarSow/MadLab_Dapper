namespace MedLab_Dapper.Dtos.AppointmentDtos;

public class CreateAppointmentDto
{
    public string PatientName { get; set; }
    public string Email { get; set; }
    public DateTime AppointmentDate { get; set; }
    public int DepartmentId { get; set; }
    public int DoctorId { get; set; }
    public string? Message { get; set; }
    public string PhoneNumber {  get; set; }
}