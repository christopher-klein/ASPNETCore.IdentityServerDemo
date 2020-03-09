using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ASPNETCore.IdentityServerDemo.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ASPNETCore.IdentityServerDemo.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            // inject default logger, it is not used in my example
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> GetWeatherData()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IEnumerable<SimpleClaim> GetSecretClaimData()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;

            //cast into simplier model type
            List<SimpleClaim> returnClaims = new List<SimpleClaim>();
            foreach(var claim in claimsIdentity.Claims)
            {
                returnClaims.Add(new SimpleClaim()
                {
                    Type = claim.Type,
                    Value = claim.Value
                });
            }

            return returnClaims;
        }
    }
}
