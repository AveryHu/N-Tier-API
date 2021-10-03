using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Domain.DTO;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<WeatherForecast>> Get()
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

        [HttpGet("{id}")]
        public ActionResult<WeatherForecast> Get(int id)
        {
            return Ok(new WeatherForecast());
        }

        [HttpPost]
        public ActionResult Post([FromBody] WeatherForecast value)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Remove(int id, [FromBody] WeatherForecast value)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            return Ok();
        }
    }
}
