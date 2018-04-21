using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
 
namespace random_passcode
{
    public class SleepController : Controller
    {
        [HttpGet]
        [Route("/sleep")]
        public IActionResult Sleep()
        {
            int? fullness = HttpContext.Session.GetInt32("fullness");
            fullness -= 5;
            HttpContext.Session.SetInt32("fullness", (int)fullness);
            int? happiness = HttpContext.Session.GetInt32("happiness");
            happiness -= 5;
            HttpContext.Session.SetInt32("happiness", (int)happiness);
            int? energy = HttpContext.Session.GetInt32("energy");
            energy += 15;
            HttpContext.Session.SetInt32("energy", (int)energy);
            HttpContext.Session.SetString("message", "You put your Dojo Dachi to sleep. Energy +15, Fullness -5, Happiness -5");
            return Redirect("/");
        }
    }
}