using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chatroom.API.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ChatRoom",
                    Description = "Allow registered users to log in and talk with other users in a chatroom.",
                    Contact = new OpenApiContact
                    {
                        Name = "Fryann Martinez",
                        Email = "fryannm@gmail.com",
                        Url = new Uri("https://fryannm.github.io"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under MIT",
                        Url = new Uri("https://fryannm.github.io"),
                    }
                });
            });

            services.AddControllers();
        }
    }
}
