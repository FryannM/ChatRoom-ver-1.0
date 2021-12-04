using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Chatroom.Test.Service.WeatherForecast
{
    public class WeatherForecastServiceTest
    {
        [Fact]
        public void Test_GetAllWeatherForecast_Found()
        {
            int cantidad = 5;
            var Service = WeatherForecastServiceFactory.GetService();
            var Result = Service.GetAllWeatherForecast();

            Assert.Equal(cantidad, Result.Count());

        }

    }
}
