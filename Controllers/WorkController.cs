using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
 
namespace random_passcode
{
    public class WorkController : Controller
    {
        [HttpGet]
        [Route("/work")]
        public IActionResult Work()
        {
            int? energy = HttpContext.Session.GetInt32("energy");
            if (energy > 0){
                energy -= 5;
                HttpContext.Session.SetInt32("energy", (int)energy);
                int? meals = HttpContext.Session.GetInt32("meals");
                Random rand = new Random();
                int newMeals = rand.Next(1, 4);
                meals = meals + newMeals;
                HttpContext.Session.SetInt32("meals", (int)meals);
                HttpContext.Session.SetString("message", "Your worked your Dojo Dachi. Meals +" + newMeals + ", Energy -5");
            } else {
                HttpContext.Session.SetString("message", "Your Dojo Dachi doesn't have enough energy to work.");
            }
            return Redirect("/");
        }
    }
}