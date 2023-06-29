using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using Services.Abstract;
using Services.Concrete;

namespace DormitoryProjectAPI.Extensions
{
    public static class ConfigureDependenciesExtension
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAnnouncementService, AnnouncementService>();
            services.AddScoped<IEventParticipantService, EventParticipantService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<ISuggestion_ComplaintService, Suggestion_ComplaintService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            
            services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
            services.AddScoped<IEventParticipantRepository, EventParticipantRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<ISuggestion_ComplaintRepository, Suggestion_ComplaintRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
