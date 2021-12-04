using Chatroom.Entities.WeatherForecast;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chatroom.Service
{
    public interface IWeatherForecastService
    {
        public IEnumerable<WeatherForecast> GetAllWeatherForecast();

    }
}
