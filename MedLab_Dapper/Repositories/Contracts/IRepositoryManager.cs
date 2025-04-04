namespace MedLab_Dapper.Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IDepartmentRepository Department { get; }
        IDoctorRepository Doctor { get; }
    }
}
