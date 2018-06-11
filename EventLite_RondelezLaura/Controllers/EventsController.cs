using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventLite_RondelezLauraAPI.Entities;
using EventLite_RondelezLauraMVC.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventLite_RondelezLauraAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/events")]
    public class EventsController : Controller
    {
        private EventLiteContext db;
        public EventsController(EventLiteContext context)
        {
            db = context;
        }

        // GET: api/Events
        [HttpGet(Name = "GetEvents")]
        public IActionResult Get()
        {
            try
            {
                var events = db.Event
                                .Select(c => c)
                                .ToList();
                return Ok(events);
            }
            catch (Exception e)
            {
                return BadRequest($"O oh, something ({e.Message}) went wrong");
            }
        }

        // GET: api/Events/bla
        [HttpGet("{event}", Name = "GetEvent")]
        public IActionResult Get(Event ev)
        {
            try
            {
                Event e = db.Event
                          .FirstOrDefault(c => c.Id == ev.Id);
                if (e == null)
                {
                    return NotFound($"Event with id {ev.Id} is not found...");
                }
                return Ok(e);
            }
            catch (Exception e)
            {
                return BadRequest($"O oh, something ({e.Message}) went wrong");
            }
        }

        // GET: api/Events/Subscription
        [HttpGet("{eventId}", Name = "GetSubscription")]
        public IActionResult Get(int eventId)
        {
            try
            {
                Subscription s = db.Subscription
                          .FirstOrDefault(c => c.EventId == eventId && c.VisitorId == 1);
                if (s == null)
                {
                    return Ok(false);
                }
                return Ok(true);
            }
            catch (Exception e)
            {
                return BadRequest($"O oh, something ({e.Message}) went wrong");
            }
        }

        // POST: api/Events
        [HttpPost]
        public IActionResult Post([FromBody]Event ev)
        {
            try
            {
                if (ev != null && ModelState.IsValid)
                {
                    Visitor v = new Visitor()
                    {
                        Firstname = "x",
                        Lastname = "y"
                    };
                    Subscription newSubscription = new Subscription()
                    {
                        
                        VisitorId = v.Id,
                        EventId = ev.Id
                    };
                    db.Subscription.Add(newSubscription);
                    db.SaveChanges();
                    return Created(Url.Link("GetEvents", new { id = newSubscription.Id }), newSubscription);
                }
                else
                {
                    return NotFound($"No correct Event info retrieved. Model is {ModelState.ValidationState}");
                }
            }
            catch (Exception e)
            {
                return BadRequest($"O oh, something ({e.Message}) went wrong");
            }
        }
        
    }
}
