namespace FamilyHousing.API.Configuration
{
    public class AutoMapperConfiguration
    {
        public static void AddAutoMapper(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
