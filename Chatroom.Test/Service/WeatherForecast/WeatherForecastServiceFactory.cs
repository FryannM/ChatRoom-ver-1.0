using Chatroom.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chatroom.Test.Service.WeatherForecast
{
    public class WeatherForecastServiceFactory
    {

        internal static IWeatherForecastService GetService()
        {

            return new WeatherForecastService();

        }


    }
}
