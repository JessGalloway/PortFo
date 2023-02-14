using Microsoft.AspNetCore.Mvc;

namespace PortFo.Controllers
{
    public class Home : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About() { return View(); }


        public IActionResult Contact() { return View(); }

        public IActionResult Portfolio() { return View(); }

        public IActionResult PortfolioIndex() { return View(); }

        public IActionResult Styles() { return View(); }
    }
}
