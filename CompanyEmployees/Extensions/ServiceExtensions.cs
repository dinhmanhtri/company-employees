namespace CompanyEmployees.Extensions
{
    public static class ServiceExtensions
    {
        // CORS Configuration (Cross-Origin Resource Sharing)
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()        //WithOrigins("https://example.com")
                    .AllowAnyMethod()               //WithMethods("POST", "GET")
                    .AllowAnyHeader());             //WithHeaders("accept", "content-type")
            });

        // IIS Configuration
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {

            });
    }
}
