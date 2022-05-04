using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TO_DO_Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TodoListController : ControllerBase
    {
        [HttpPut(Name ="Create")]
        public void Create()
        {

        }

        [HttpGet(Name = "Get")]
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

        [HttpDelete(Name = "Delete")]
        public void Delete(ushort Id)
        {
            CommDB.Instance.Delete(Id);
        }

        [HttpGet("{day_forward}")]
        public void fgm() { }

        [HttpOptions]
        public void Update() { }
    }
}