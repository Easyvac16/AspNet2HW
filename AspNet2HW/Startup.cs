using AspNet2HW.Abstract;
using AspNet2HW.Services;

namespace AspNet2HW
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAnimalOutputService, AnimalOutputService>();
            services.AddRazorPages();

            services.AddScoped<IFiguresOutputService, FigureOutputService>();
            services.AddRazorPages();
        }
    }
}
