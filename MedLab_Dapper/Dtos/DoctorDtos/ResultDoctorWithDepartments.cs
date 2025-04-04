using System.Security.Cryptography.Pkcs;

namespace MedLab_Dapper.Dtos.DoctorDtos
{
    public class ResultDoctorWithDepartments : DoctorDto
    {
        public int DoctorId { get; set; }
        public string DepartmentName { get; set; }
    }
}
