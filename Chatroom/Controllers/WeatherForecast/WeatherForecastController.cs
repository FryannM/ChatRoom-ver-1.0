using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chatroom.Entities.WeatherForecast;
using Chatroom.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Chatroom.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return _weatherForecastService.GetAllWeatherForecast();

        }
    }
}
