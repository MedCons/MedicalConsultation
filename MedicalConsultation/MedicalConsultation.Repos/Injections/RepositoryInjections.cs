using MedicalConsultation.Repos.Implementations;
using MedicalConsultation.Repos.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RepositoryInjection
    {
        public static void AddDepencyInjections(this IServiceCollection services)
        {
            services.AddTransient<IMessageRepo, MessageRepo>();
            services.AddTransient<IUserRepo, UserRepo>();
        }
    }
}
