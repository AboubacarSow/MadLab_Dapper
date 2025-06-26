namespace MedLab_Dapper.Repositories.Contracts;
public interface IRepositoryManager
{
    IDepartmentRepository Department { get; }
    IDoctorRepository Doctor { get; }
    IAboutRepository About { get; }
    IContactRepository Contact { get; }
    IItemRepository Item { get; }
    IMessageRepository Message { get; }
    ISocialMediaRepository SocialMedia { get; }
    IGalleryRepository Gallery { get; }
    IFrequentlyQuestionRepository FrequentlyQuestion { get; }
    IServiceRepository Service { get; }
    IAppointmentRepository Appointment { get; }
}
