using ApiWorkTools.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;

namespace ApiWorkTools.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        // GET: api/<TasksController>
        [HttpGet]
        public IEnumerable<cls_Message> Get(int in_type)
        {
            Random rnd = new Random();
            return Enumerable.Range(1, rnd.Next(5,10)).Select(index => new cls_Message
            {
                Id = index,
                From = "@user",
                Type = in_type,
                DateSend = DateTime.Now,
                DateRead = DateTime.Now,
                Message = "Por favor realizar esta tarea" + $"{index}",
                Status = "1"
            })
            .ToArray();
        }

        // GET api/<TasksController>/5
        [HttpGet("{id}")]
        public IEnumerable<cls_Message> Get(int in_type, int id)
        {
            return Enumerable.Range(1, 1).Select(index => new cls_Message
            {
                Id = index,
                From = "@user",
                Type = in_type,
                DateSend = DateTime.Now,
                DateRead = DateTime.Now,
                Message = "Por favor realizar esta tarea" + $"{index}",
                Status = "1"
            })
           .ToArray();
        }

        // POST api/<TasksController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
