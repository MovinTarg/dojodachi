using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
 
namespace random_passcode
{
    public class PlayController : Controller
    {
        [HttpGet]
        [Route("/play")]
        public IActionResult Play()
        {
            int? energy = HttpContext.Session.GetInt32("energy");
            if (energy > 0){
                energy -= 5;
                HttpContext.Session.SetInt32("energy", (int)energy);
                int? happiness = HttpContext.Session.GetInt32("happiness");
                Random rand = new Random();
                int happier = rand.Next(5, 11);
                happiness = happiness + happier;
                HttpContext.Session.SetInt32("happiness", (int)happiness);
                HttpContext.Session.SetString("message", "You played with your Dojo Dachi. Happiness +" + happier + ", Energy -5");
            } else {
                HttpContext.Session.SetString("message", "Your Dojo Dachi doesn't have enough energy to play.");
            }
            return Redirect("/");
        }
    }
}