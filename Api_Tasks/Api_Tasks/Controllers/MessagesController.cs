using Api_Tasks.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_Tasks.Controllers
{
    [Route("api/messages")]
    [ApiController]
    public class MessagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet(Name = "GetAllMessages")]
        public IEnumerable<cls_Message> GetAllMessages(int in_type)
        {
            return Enumerable.Range(1, 5).Select(index => new cls_Message
            {
                Id = index,
                From = "@user",
                Type = in_type,
                DateSend = DateTime.Now,
                DateRead = DateTime.Now,
                Description = "Por favor realizar esta tarea" + $"{index}",
                Status = "1"
            })
            .ToArray();
        }
    }
}
