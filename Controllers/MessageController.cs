using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;
 
namespace api.Controllers
{
    public class MessageController : ControllerBase
    {
        IRepository<Message, Guid> repoMes;
        IRepository<Message, Guid> repository;
        public MessageController(IRepository<Message, Guid> rm,IRepository<Message, Guid> r)
        {
            repoMes = rm;
            repository = r;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Get()
        {
            return Ok("Get disabled for now");
            var messages = repository.Get();
            return Ok(messages);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult Post([FromBody] Message message)
        {
            repository.Create(message);
            return Ok(message);
        }
    }
}