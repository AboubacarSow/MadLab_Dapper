using Dapper;
using MedLab_Dapper.Dtos.DoctorDtos;
using MedLab_Dapper.Repositories.Context;
using MedLab_Dapper.Repositories.Contracts;

namespace MedLab_Dapper.Repositories.Models
{
    public class DoctorRepository(DapperDbContext _context) : IDoctorRepository
    {
        public async Task CreateOneDoctorAsync(CreateDoctorDto doctor)
        {
            var query = "insert into Doctors (FullName,ImageUrl,Description,DepartmentId)" +
                "values (@FullName, @ImageUrl,@Description,@DepartmentId)";
            var parameters = new DynamicParameters(doctor);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteOneDoctorAsync(int id)
        {
            string query = "delete from Doctors where DoctorId=@doctorId";
            var parameter = new DynamicParameters();
            parameter.Add("@doctorId", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameter);
        }

        public async Task<IEnumerable<ResultDoctorDto>> GetAllAsync()
        {
            var queryString = "select * from Doctors";
            var connection = _context.CreateConnection();
            return await connection.QueryAsync<ResultDoctorDto>(queryString);
        }

        public async Task<IEnumerable<ResultDoctorWithDepartments>> GetAllWithDepartmentAsync()
        {
            var query = @"select DoctorId,FullName,Doctors.ImageUrl,Doctors.Description,DepartmentName from Doctors
                inner join Departments on Doctors.DepartmentId=Departments.DepartmentId";
            var connection = _context.CreateConnection();
            return await connection.QueryAsync<ResultDoctorWithDepartments>(query);
        }

        public async Task<GetDoctorById> GetByIdAsync(int id)
        {
            var query = "select * from Doctors where DoctorId=@doctorId";
            var parameter = new DynamicParameters();
            parameter.Add("@doctorId", id);
            var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<GetDoctorById>(query, parameter);
        }

        public async Task UpdateOneDoctorAsync(UpdateDoctorDto doctor)
        {
            string query = @"update Doctors set FullName=@fullName,ImageUrl=@imageUrl, Description=@description ,DepartmentId=@departmentId
                 where DoctorId=@doctorId";
            var parameters = new DynamicParameters(doctor);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
