using MedLab_Dapper.Repositories.Contracts;

namespace MedLab_Dapper.Repositories.Models;

public class RepositoryManager : IRepositoryManager
{

    private readonly IDepartmentRepository _departmentServie;
    private readonly IDoctorRepository _doctorService;
    private readonly IAboutRepository _aboutService;
    private readonly IContactRepository _contact;
    private readonly IItemRepository _item;
    private readonly IMessageRepository _message;
    private readonly ISocialMediaRepository _socialMedia;
    private readonly IGalleryRepository _gallery;
    private readonly IFrequentlyQuestionRepository _frequentlyQuestion;
    private readonly IServiceRepository _service;
    private readonly IAppointmentRepository _appointment;
    private readonly ITestimonialRepository _testimonial;

    public RepositoryManager(IDoctorRepository doctorService, IDepartmentRepository departmentServie,
        IAboutRepository aboutService, IContactRepository contact, IItemRepository item, IMessageRepository message,
         ISocialMediaRepository socialMedia, IGalleryRepository gallery,
         IFrequentlyQuestionRepository frequentlyQuestion, IServiceRepository service,
          IAppointmentRepository appointment, ITestimonialRepository testimonial)
    {
        _doctorService = doctorService;
        _departmentServie = departmentServie;
        _aboutService = aboutService;
        _contact = contact;
        _item = item;
        _message = message;
        _socialMedia = socialMedia;
        _gallery = gallery;
        _frequentlyQuestion = frequentlyQuestion;
        _service = service;
        _appointment = appointment;
        _testimonial = testimonial;
    }

    public IDepartmentRepository Department => _departmentServie;
    public IDoctorRepository Doctor => _doctorService;
    public IAboutRepository About => _aboutService;
    public IContactRepository Contact => _contact;
    public IItemRepository Item => _item;
    public IMessageRepository Message => _message;
    public ISocialMediaRepository SocialMedia => _socialMedia;
    public IGalleryRepository Gallery => _gallery;
    public IFrequentlyQuestionRepository FrequentlyQuestion => _frequentlyQuestion;
    public IServiceRepository Service => _service;
    public IAppointmentRepository Appointment => _appointment;

    public ITestimonialRepository Testimonial => _testimonial;
}

