using MedLab_Dapper.Dtos.DepartmentDtos;

namespace MedLab_Dapper.Repositories.Contracts
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<ResultDepartmentDto>> GetAllDepartmentAsync();
        Task<GetDepartmentById> GetDepartmentByIdAsync(int id);
        Task<UpdateDepartmentDto> GetDepartmentForUpdate(int id);


        Task CreateOneDepartment(CreateDepartmentDto departmentDto);
        Task UpdateOneDepartmentAsync(UpdateDepartmentDto departementDto);
        Task DeleteOneDepartmentAsync(int id);
    }
}
