using PetaevDanilKt_31_21.Interfaces.StudentInterfaces;

namespace PetaevDanilKt_31_21.ServiceExtentions
{
    public static class ServiceExtentions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IGradeService, GradeService>();

            services.AddScoped<IGroupService, GroupService>();

            return services;
        }
    }
}
