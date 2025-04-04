using MedLab_Dapper.Repositories.Contracts;

namespace MedLab_Dapper.Repositories.Models
{
    public class RepositoryManager : IRepositoryManager
    {

        private readonly IDepartmentRepository _departmentServie;
        private readonly IDoctorRepository _doctorService;

        public RepositoryManager(IDoctorRepository doctorService, IDepartmentRepository departmentServie)
        {
            _doctorService = doctorService;
            _departmentServie = departmentServie;
        }

        public IDepartmentRepository Department => _departmentServie;

        public IDoctorRepository Doctor => _doctorService;
    }
}
