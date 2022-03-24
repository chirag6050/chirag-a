using Chirag.BookReadingEvent.Web.Interfaces;
using Chirag.BookReadingEvent.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Chirag.BookReadingEvent.Web.Controllers
{  // main page for the action method
       public class HomeController : Controller
        {
            private readonly IEventPageService _eventPageService;

            public HomeController(IEventPageService eventPageService)
            {
                this._eventPageService = eventPageService;
            }
            [Route("")]
            public async Task<IActionResult> Index()
            {
                var eventList = await _eventPageService.GetEvents();
                return View(eventList);
            }

            [Route("Privacy")]
            public IActionResult Privacy()
            {
                return View();
            }

            [Route("about-us")]
            public IActionResult About()
            {
                return View();
            }

            [Route("customer-support")]
            public IActionResult CustomerSupport()
            {
                return Redirect("http://helpdesk.nagarro.com");
            }



        }
    }
