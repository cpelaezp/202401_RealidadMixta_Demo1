using ApiWorkTools.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiWorkTools.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        // GET: api/<TasksController>
        [HttpGet]
        public IEnumerable<cls_Task> Get()
        {
            Random rnd = new Random();
            return Enumerable.Range(1, rnd.Next(5, 10)).Select(index => new cls_Task
            {
                Id = index,
                Start = DateTime.Now,
                End = DateTime.Now,
                Name = "Task" + $"{index}",
                Description = "Deccripción de la Tarea " + $"{index}",
                Status = "1"
            })
            .ToArray();
        }

        // GET api/<TasksController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TasksController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }        
    }
}
