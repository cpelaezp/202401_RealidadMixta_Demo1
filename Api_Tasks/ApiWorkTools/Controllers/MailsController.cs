using ApiWorkTools.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiWorkTools.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        // GET: api/<MailsController>
        [HttpGet]
        public IEnumerable<cls_Mail> Get()
        {
            Random rnd = new Random();
            return Enumerable.Range(1, rnd.Next(20, 50)).Select(index => new cls_Mail
            {
                Id = index,
                From = "@user",
                To = "@to",
                DateSend = DateTime.Now,
                DateRead = DateTime.Now,
                Message = "Por favor realizar esta tarea" + $"{index}",
                Status = "1"
            })
            .ToArray();
        }
        // GET api/<MailsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MailsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
