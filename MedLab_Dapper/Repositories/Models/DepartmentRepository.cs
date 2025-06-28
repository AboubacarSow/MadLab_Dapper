using Dapper;
using MedLab_Dapper.Dtos.DepartmentDtos;
using MedLab_Dapper.Repositories.Context;
using MedLab_Dapper.Repositories.Contracts;

namespace MedLab_Dapper.Repositories.Models
{
    public class DepartmentRepository(DapperDbContext dbContext) : IDepartmentRepository
    {
        private readonly DapperDbContext _dbContext = dbContext;

        public async Task CreateOneDepartment(CreateDepartmentDto departmentDto)
        {
            var query = "insert into Departments (DepartmentName,Description,ImageUrl) " +
                "values (@departmentName, @description,@imageUrl)";
            var parameters = new DynamicParameters();
            parameters.Add("@departmentName", departmentDto.DepartmentName);
            parameters.Add("@description", departmentDto.Description);
            parameters.Add("@imageUrl", departmentDto.ImageUrl);
            var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteOneDepartmentAsync(int id)
        {
            string query = "delete from Departments where DepartmentId=@departmentId";
            var parameter = new DynamicParameters();
            parameter.Add("@departmentId", id);
            var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query, parameter);
        }

        public Task<IEnumerable<ResultDepartmentDto>> GetAllDepartmentAsync()
        {
            string query = "select * from Departments";
            var connection = _dbContext.CreateConnection();
            return connection.QueryAsync<ResultDepartmentDto>(query);
        }

        public async Task<GetDepartmentById> GetDepartmentByIdAsync(int id)
        {
            string query = "select * from Departments where DepartmentId=@departmentId";
            var connection = _dbContext.CreateConnection();
            var parameter = new DynamicParameters();
            parameter.Add("@departmentId", id);
            return  await connection.QueryFirstOrDefaultAsync<GetDepartmentById>(query, param:parameter);
        }

        public async Task<UpdateDepartmentDto> GetDepartmentForUpdate(int id)
        {
            string query = "select * from Departments where DepartmentId=@departmentId";
            var connection = _dbContext.CreateConnection();
            var parameter = new DynamicParameters();
            parameter.Add("@departmentId", id);
            return await connection.QueryFirstOrDefaultAsync<UpdateDepartmentDto>(query, param: parameter);
        }

        public async Task UpdateOneDepartmentAsync(UpdateDepartmentDto departementDto)
        {
            string query = "update Departments set DepartmentName=@DepartmentName, Description=@Description, ImageUrl=@ImageUrl" +
                "where DepartmentId=@DepartmentId";
            var parameters = new DynamicParameters();
            parameters.Add("@DepartmentId", departementDto.DepartmentId);
            parameters.Add("@DepartmentName", departementDto.DepartmentName);
            parameters.Add("@Description", departementDto.Description);
            parameters.Add("@ImageUrl", departementDto.ImageUrl);
            var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
