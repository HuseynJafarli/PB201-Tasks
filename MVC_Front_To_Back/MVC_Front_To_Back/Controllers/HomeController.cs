using Microsoft.AspNetCore.Mvc;
using MVC_Front_To_Back.Models;
using MVC_Front_To_Back.ViewModels;

namespace MVC_Front_To_Back.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Slide> slides = new List<Slide>
            {
                new Slide
                {
                    Id = 1,
                    Title = "New Plant 1",
                    SubTitle= "60% OFF",
                    Description = "We have more check them",
                    Order = 2,
                    Image = "1-2-524x617.png"
                },
                new Slide
                {
                    Id = 2,
                    Title = "New Plant 2",
                    SubTitle= "70% OFF",
                    Description = "We have more check them",
                    Order = 3,
                    Image = "1-1-524x617.png"
                },
                new Slide
                {
                    Id = 3,
                    Title = "New Plant 3",
                    SubTitle= "80% OFF",
                    Description = "We have more check them",
                    Order = 1,
                    Image = "1-3.png"
                }

            };


            HomeVM homeVM = new HomeVM
            {
                Slides = slides.OrderBy(x => x.Order).ToList()
            };

            return View(homeVM);
        }
    }
}
