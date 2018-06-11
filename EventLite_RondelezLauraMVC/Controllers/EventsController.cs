using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using EventLite_RondelezLauraMVC.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EventLite_RondelezLauraMVC.Controllers
{
    [Route("")]
    [Route("[controller]")]
    public class EventsController : Controller
    {
        private HttpClient client;

        public EventsController()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:5005")
            };
        }

        #region Get list of Events
        [Route("")]
        [Route("[controller]/[action]")]
        [Route("[controller]")]
        [AllowAnonymous]
        public IActionResult List()
        {
            string eventsResult = client.GetStringAsync("api/events").Result;
            List<Event> eventsData = JsonConvert.DeserializeObject<List<Event>>(eventsResult);

            return View(eventsData);
        }
        #endregion

        #region Get details of Event
        [Route("[controller]/[action]")]
        [Authorize]
        public IActionResult Details(Event ev)
        {
            string eventResult = client.GetStringAsync("api/events").Result;
            List<Event> eventData = JsonConvert.DeserializeObject<List<Event>>(eventResult);

            return View(eventData);
        }
        #endregion
        
        #region Add subscription
        [Route("[action]")]
        [Authorize]
        [HttpPost]
        public IActionResult Add(Event ev)
        {
            HttpResponseMessage subscriptionResult = client
                                .PostAsJsonAsync("/api/events", ev)
                                .Result;
            if (subscriptionResult.StatusCode == HttpStatusCode.Created)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Error", "Validation error!");
                return View(ev);
            }
        }
        #endregion
    }
}