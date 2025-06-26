using MedLab_Dapper.Repositories.Context;
using MedLab_Dapper.Repositories.Contracts;
using MedLab_Dapper.Repositories.Models;

namespace MedLab_Dapper.Infrastructure.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IAboutRepository, AboutRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IGalleryRepository, GalleryRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IFrequentlyQuestionRepository, FrequentlyQuestionRepository>();
            services.AddScoped<DapperDbContext>();
        }
    }
}
