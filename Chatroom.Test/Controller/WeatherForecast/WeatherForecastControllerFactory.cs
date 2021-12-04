using Chatroom.Controllers;
using Chatroom.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chatroom.Test.Controller.WeatherForecast
{
    public class WeatherForecastControllerFactory
    {
        public static WeatherForecastController GetController(IMock<IWeatherForecastService> mockWeatherForecastService = null)
        {
            if (mockWeatherForecastService == null)
                mockWeatherForecastService = new Mock<IWeatherForecastService>();

            return new WeatherForecastController(mockWeatherForecastService.Object);
        }

        internal static Mock<IWeatherForecastService> GetMock()
        {
            var service = new Mock<IWeatherForecastService>();

            service.Setup(x => x.GetAllWeatherForecast())
                .Returns(new List<Chatroom.Entities.WeatherForecast.WeatherForecast>() { 
                    new Entities.WeatherForecast.WeatherForecast()
                    {
                        Id = 1

                    },
                    new Entities.WeatherForecast.WeatherForecast()
                    {
                        Id = 2

                    }
                });

            return service;
        }
        
        internal static Mock<IWeatherForecastService> GetMockNotFound()
        {
            var service = new Mock<IWeatherForecastService>();

            service.Setup(x => x.GetAllWeatherForecast())
                .Returns(new List<Chatroom.Entities.WeatherForecast.WeatherForecast>(){});

            return service;
        }
    }
}
