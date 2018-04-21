using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
 
namespace random_passcode
{
    public class FeedController : Controller
    {
        [HttpGet]
        [Route("/feed")]
        public IActionResult Feed()
        {
            int? meals = HttpContext.Session.GetInt32("meals");
            if (meals > 0){
                meals -= 1;
                HttpContext.Session.SetInt32("meals", (int)meals);
                int? fullness = HttpContext.Session.GetInt32("fullness");
                Random rand = new Random();
                int liked = rand.Next(1, 5);
                if (liked == 2){
                    HttpContext.Session.SetString("message", "You tried to feed your Dojo Dachi, but it didn't like the meal. Meals -1.");
                } else {
                    int food = rand.Next(5, 11);
                    fullness = fullness + food;
                    HttpContext.Session.SetInt32("fullness", (int)fullness);
                    HttpContext.Session.SetString("message", "You fed your Dojo Dachi. Meals -1, Fullness +" + food);
                }
            } else {
                HttpContext.Session.SetString("message", "You have no food to feed your Dojo Dachi.");
            }
            return Redirect("/");
        }
    }
}