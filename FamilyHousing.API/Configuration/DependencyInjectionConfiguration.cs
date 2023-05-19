using FamilyHousing.Data.Repositories;
using FamilyHousing.Domain.Contracts.Repositories;
using FamilyHousing.Domain.Contracts.Services;
using FamilyHousing.Domain.Services;

namespace FamilyHousing.API.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void DependencyInjection(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IFamilyService, FamilyService>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
