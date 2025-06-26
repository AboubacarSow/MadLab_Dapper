namespace MedLab_Dapper.Dtos.AppointmentDtos;

public class UpdateAppointmentDto
{
    public int Id { get; set; }
    public string PatientName { get; set; }
    public string Email { get; set; }
    public DateTime AppointmentDate { get; set; }
    public int DepartmentId { get; set; }
    public int DoctorId { get; set; }
    public string? Message { get; set; }
}
