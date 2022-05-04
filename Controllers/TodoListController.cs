using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TO_DO_Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TodoListController : ControllerBase
    {
        private readonly ILogger<TodoListController> _logger;

        public TodoListController(ILogger<TodoListController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Item> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Item
            {
                Expiry = DateTime.Now.AddDays(index),
                Title = "Random.Shared.Next(-20, 55)",
                Description = "Summary = Summaries[Random.Shared.Next(Summaries.Length)]",
                Percent = 250
            })
            .ToArray();
        }
    }
}