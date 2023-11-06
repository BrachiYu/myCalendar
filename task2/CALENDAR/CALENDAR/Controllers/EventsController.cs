using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CALENDAR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private static List<Event> events = new List<Event> { new Event { Id=1
            ,Title = "default event",Start=DateTime.Now},
            new Event{Id=2,Title = "default event",Start=DateTime.Now}};
        
        
        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return events;
        }

        //// GET api/<EventsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<EventsController>
        [HttpPost]
        public Event Post([FromBody] Event eve)
        {
            eve.Id++;
            events.Add(eve);
            return eve;
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            var del = events.Find(e => e.Id == id);
            del.Title=value;
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var del=events.Find(e => e.Id == id);
            events.Remove(del);
        }
    }
}

