using DungeonsAndDragonsWeb.Models.Database;
using DungeonsAndDragonsWeb.Models.Resources;
using DungeonsAndDragonsWeb.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonsAndDragonsWeb.Controllers
{
    [ApiController]
    [Route("UserController")]
    public class UserController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        public UserController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost("Login")]
        public UserResponse Login([FromBody] User u)
        {
            if (string.IsNullOrEmpty(u.Email) || string.IsNullOrEmpty(u.Password)) return new UserResponse(false, "Neither email nor password can be empty!");
            else if (DatabaseDelegator.CheckPassword(u)) return new UserResponse(true);
            else return new UserResponse(false, "User does not exist!");
        }
    }
}
