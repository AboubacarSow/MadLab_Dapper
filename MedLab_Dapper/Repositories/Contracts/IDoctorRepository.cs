using MedLab_Dapper.Dtos.DepartmentDtos;
using MedLab_Dapper.Dtos.DoctorDtos;

namespace MedLab_Dapper.Repositories.Contracts
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<ResultDoctorDto>> GetAllAsync();
        Task<IEnumerable<ResultDoctorWithDepartments>> GetAllWithDepartmentAsync();
        Task<GetDoctorById> GetByIdAsync(int id);
        Task CreateOneDoctorAsync(CreateDoctorDto doctor);
        Task UpdateOneDoctorAsync(UpdateDoctorDto doctor);

        Task<IEnumerable<ResultDoctorDto>> GetDoctorsByDepartmentAsync(int departmentId);
        Task DeleteOneDoctorAsync(int id);
    }
}
