using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace multilang
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IStringLocalizer<WeatherForecastController> _stringLocalizer;
        private readonly IStringLocalizer<SharedResource> _sharedResourceLocalizer;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(
            IStringLocalizer<WeatherForecastController> stringLocalizer,
            IStringLocalizer<SharedResource> sharedResourceLocalizer,
            ILogger<WeatherForecastController> logger)
        {
            _stringLocalizer = stringLocalizer;
            _sharedResourceLocalizer = sharedResourceLocalizer;
            _logger = logger;
        }

        [HttpGet]
        [Route("WeatherForcastControllerResource")]
        public IActionResult GetUsingPostsControllerResource()
        {
            var article = _stringLocalizer["Artical"];
            var postName = _stringLocalizer.GetString("Hello").Value ?? "";

            return Ok(new { PostType = article.Value, PostName = postName });
        }
    }
}