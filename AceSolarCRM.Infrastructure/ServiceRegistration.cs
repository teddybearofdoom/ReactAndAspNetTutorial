using AceSolarCRM.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using Repository.AppInterface.Interfaces;
using System.Runtime.CompilerServices;

namespace AceSolarCRM.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ILeadRepository, LeadRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>(); 
        }
    }
}