using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using PortFo.Models;

namespace PortFo.Controllers
{
    public class Home : Controller
    {
        private readonly IConfiguration _config;

        public Home(IConfiguration config) 
        {
            _config = config; 
        }

        public IActionResult Contact() { return View(); }

        [HttpPost]
        public IActionResult Contact(ContactViewModel cvm)
        {
            if (!ModelState.IsValid) 
            { 
                return View(cvm);
            }

            string message = $"You have received a new email from your site's contact form!<br/>" +
            $"Sender: {cvm.Name}<br/>Email: {cvm.Email}<br/>Subject: {cvm.Subject}<br/>Message: {cvm.Message}";

            var mm = new MimeMessage();

            mm.From.Add(new MailboxAddress("Sender", _config.GetValue<string>("Credentials:Email:Recipient")));

            mm.Subject = cvm.Subject;

            mm.Body = new TextPart("HTML") { Text = message };

            mm.Priority = MessagePriority.Urgent;

            mm.ReplyTo.Add(new MailboxAddress("User", cvm.Email));

            using (var client = new SmtpClient())
            {
                client.Connect(_config.GetValue<string>("Crendentials:Email:Client"));

                client.Authenticate(

                    _config.GetValue<string>("Credentials:Email:User"),

                    _config.GetValue<string>("Credentials.Email.Password")

                    );

                try 
                {
                    client.Send(mm);
                
                }
                catch (Exception ex) 
                {

                    ViewBag.ErrorMessage = $"Error processing request at this time. Please tyr again later or contact via" +
                        $"phone number in the contact information section of this page.<br />Error Message: {ex.StackTrace}";

                    return View(cvm);
                    
                }
            
            }
            return View("EmailConfirmation", cvm);
        }

       

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About() { return View(); }


      

        public IActionResult Portfolio() { return View(); }

        public IActionResult PortfolioIndex() { return View(); }

        public IActionResult Styles() { return View(); }
    }
}
