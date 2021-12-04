using Chatroom.DataAccess;
using Chatroom.Service;
using Chatroom.Service.ChatRoom;
using Chatroom.Service.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chatroom.API.Installers
{
    public class DataInstallers : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //Registering DBContext
            services.AddDbContext<ApplicationDbContext>(opt => 
                opt.UseSqlServer(configuration.GetConnectionString("DatabaseConnection")));

            //DI
            services.AddTransient<IWeatherForecastService, WeatherForecastService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IChatRoomServices, ChatRoomServices>();

            //JWT Setting
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));


            // automapper

        }
    }
}
