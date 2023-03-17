using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;

namespace PortFo.Controllers
{
    public class Home : Controller
    {
        private readonly IConfiguration _config;

        public Home(IConfiguration config) { _config = config; }


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
