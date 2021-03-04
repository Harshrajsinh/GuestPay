using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GuestPay.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace GuestPay.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult SubscriberDetails()
        {
            //StringValues userName;
            //var userName = HttpContext.Request.Headers["UserName"].ToString();
            var userName = "e3104";
            HttpContext.Session.SetString("userName",userName);
            return View();
        }

        [HttpPost]
        public IActionResult SubscriberDetails(SubscriberDetails subscriberDetails)
        {

            //if (!ModelState.IsValid)
            //    return View();
            //var userName = HttpContext.Session.GetString("userName");




            
            var sb = subscriberDetails;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
