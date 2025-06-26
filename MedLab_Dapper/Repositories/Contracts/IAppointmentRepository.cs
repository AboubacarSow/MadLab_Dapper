using MedLab_Dapper.Dtos.AppointmentDtos;

namespace MedLab_Dapper.Repositories.Contracts;

public interface IAppointmentRepository
{
    Task<IEnumerable<ResultAppointmentDto>> GetAllAsync();
    Task<UpdateAppointmentDto> GetByIdAsync(int id);
    Task CreateAsync(CreateAppointmentDto appointment);
    Task UpdateAsync(UpdateAppointmentDto appointment);
    Task DeleteAsync(int id);
}

