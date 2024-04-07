using Api_Tasks.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Tasks.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {

        [HttpGet(Name = "GetAllTasks")]
        public IEnumerable<cls_Task> GetAllTasks()
        {
            return Enumerable.Range(1, 5).Select(index => new cls_Task
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
    }


}
