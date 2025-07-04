using Dapper;
using MedLab_Dapper.Dtos.AppointmentDtos;
using MedLab_Dapper.Repositories.Context;
using MedLab_Dapper.Repositories.Contracts;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace MedLab_Dapper.Repositories.Models;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly DapperDbContext _context;
    public AppointmentRepository(DapperDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<ResultAppointmentDto>> GetAllAsync()
    {
        var query = @"
            SELECT Id, PatientName,Email,DepartmentName,FullName,Message,AppointmentDate FROM Appointments as A
            inner join Doctors as Do on A.DoctorId=Do.DoctorId inner join Departments as De on A.DepartmentId=De.DepartmentId";
        return await _context.CreateConnection().QueryAsync<ResultAppointmentDto>(query);
    }
    public async Task<UpdateAppointmentDto> GetByIdAsync(int id)
    {
        var query = @"
            SELECT * FROM Appointments
            WHERE Id = @Id";
        var parameters = new DynamicParameters();
        parameters.Add("Id", id);
        return await _context.CreateConnection().QueryFirstOrDefaultAsync<UpdateAppointmentDto>(query, parameters);
    }
    public async Task CreateAsync(CreateAppointmentDto appointment)
    {
        
        var query = @"
            INSERT INTO Appointments (PatientName, Email, AppointmentDate,DepartmentId, DoctorId, Message, PhoneNumber)
            VALUES (@PatientName, @Email, @AppointmentDate, @DepartmentId, @DoctorId, @Message, @PhoneNumber)";
        var parameters = new DynamicParameters(appointment);
        await _context.CreateConnection().ExecuteAsync(query, parameters);
    }
    public async Task UpdateAsync(UpdateAppointmentDto appointment)
    {
        var query = @"
            UPDATE Appointments
            SET PatientName = @PatientName, Email = @Email, AppointmentDate = @AppointmentDate, 
                DepartmentId = @DepartmentId, DoctorId = @DoctorId, Message = @Message, PhoneNumber=@PhoneNumber
            WHERE Id = @Id";
        var parameters = new DynamicParameters(appointment);
        await _context.CreateConnection().ExecuteAsync(query, parameters);
    }
    public async Task DeleteAsync(int id)
    {
        var query = @"
            DELETE FROM Appointments
            WHERE Id = @Id";
        var parameters = new DynamicParameters();
        parameters.Add("Id", id);
        await _context.CreateConnection().ExecuteAsync(query, parameters);
    }
}