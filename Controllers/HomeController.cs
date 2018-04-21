using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
 
namespace random_passcode
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            int? fullness = HttpContext.Session.GetInt32("fullness");
            if(fullness == null)
            {
                fullness = 20;
            }
            ViewBag.fullness = fullness;
            HttpContext.Session.SetInt32("fullness", (int)fullness);

            int? happiness = HttpContext.Session.GetInt32("happiness");
            if(happiness == null)
            {
                happiness = 20;
            }
            ViewBag.happiness = happiness;
            HttpContext.Session.SetInt32("happiness", (int)happiness);

            int? meals = HttpContext.Session.GetInt32("meals");
            if(meals == null)
            {
                meals = 3;
            }
            ViewBag.meals = meals;
            HttpContext.Session.SetInt32("meals", (int)meals);

            int? energy = HttpContext.Session.GetInt32("energy");
            if(energy == null)
            {
                energy = 50;
            }
            ViewBag.energy = energy;
            HttpContext.Session.SetInt32("energy", (int)energy);

            ViewBag.message = HttpContext.Session.GetString("message");
            if(fullness > 99 && happiness > 99){
                ViewBag.message = "Congradulations you won!";
            }
            if(fullness < 1 || happiness < 1){
                 ViewBag.message = "Your Dojodachi passed away...";
            }
            return View();
            //OR
            // return View("Index");
            //Both of these returns will render the same view (You only need one!)
        }
        [HttpGet]
        [Route("/restart")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}