using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OnlineTutor.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace OnlineTutor.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IConfiguration Config;

        //public HomeController(IConfiguration config)
        //{
        //    Config = config;
        //}

        public IActionResult Index()
        {
            ViewData["Message"] = "Home";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "About Us";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact";

            return View();
        }

        public IActionResult Projects()
        {
            ViewData["Message"] = "Projects";

            return View();
        }

        public IActionResult Events()
        {
            ViewData["Message"] = "Events";

            return View();
        }

        public IActionResult Courses()
        {
            ViewData["Message"] = "Courses";

            return View();
        }

        public IActionResult Videos()
        {
            ViewData["Message"] = "Class Videos";
            return View();
        }

        public IActionResult Signup()
        {
            ViewData["Message"] = "Sign Up";
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Message"] = "Privacy Policy";
            return View();
        }

        public IActionResult Donate()
        {
            ViewData["Message"] = "Donate";
            return View();
        }
        [HttpPost]
        public IActionResult SendContactEmail(string name, string email, string message)
        {
            ViewData["Message"] = "Contact";
            try
            {
                var msg = "Contact Email Received: <br>" + Environment.NewLine + "Name: " + name + "<br>" + Environment.NewLine;
                msg += "email: " + email + "<br>" + Environment.NewLine;
                msg += "Message: " + message + "<br>" + Environment.NewLine;

                //MailMessage a = new MailMessage();
                //a.From = new MailAddress(email);
                //a.To = new MailAddressCollection(){ new MailAddress("contact.illumony@gmail.com") };

                // add from,to mailaddresses
                MailAddress from = new MailAddress(email, "Illumony Web Site");
                MailAddress to = new MailAddress("contact.illumony@gmail.com", "Illumony Contact");
                MailMessage myMail = new System.Net.Mail.MailMessage(from, to);

                // add ReplyTo
                MailAddress replyto = new MailAddress(email);
                myMail.ReplyToList.Add(replyto);

                // set subject and encoding
                myMail.Subject = "Contact Email Received From Illumony web site";
                myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                // set body-message and encoding
                myMail.Body = msg;
                myMail.BodyEncoding = System.Text.Encoding.UTF8;
                // text or html
                myMail.IsBodyHtml = true;
                SendGridMail(myMail);
                ViewData["ConfirmMessage"] = "Thank you for contacting us!";

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ViewData["ConfirmMessage"] = "The email has failed to send out! "; // + e.Message + Environment.NewLine + e.StackTrace;
                //throw;
            }
            
            return View("Contact");
        }

        [HttpPost]
        public IActionResult SendSignupEmail(string firstName, string lastName, string email, string phone, string gender, string grade, string course, string message)
        {
            ViewData["Message"] = "Sign Up";
            try
            {
                var msg = "Contact Email Received: <br>" + Environment.NewLine + "Student First Name: " + firstName + "<br>" + Environment.NewLine;
                msg += "Student Last Name: " + lastName + "<br>" + Environment.NewLine;
                msg += "email: " + email + "<br>" + Environment.NewLine;
                msg += "phone: " + phone + "<br>" + Environment.NewLine;
                msg += "gender: " + gender + "<br>" + Environment.NewLine;
                msg += "grade: " + grade + "<br>" + Environment.NewLine;
                msg += "course: " + course + "<br>" + Environment.NewLine;
                msg += "Message: " + message + "<br>" + Environment.NewLine;


                // add from,to mailaddresses
                MailAddress from = new MailAddress(email, "Illumony Web Site");
                MailAddress to = new MailAddress("contact.illumony@gmail.com", "Illumony Contact");
                MailMessage myMail = new System.Net.Mail.MailMessage(from, to);

                // add ReplyTo
                MailAddress replyto = new MailAddress(email);
                myMail.ReplyToList.Add(replyto);

                // set subject and encoding
                myMail.Subject = "Sign up Received From Illumony web site";
                myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                // set body-message and encoding
                myMail.Body = msg;
                myMail.BodyEncoding = System.Text.Encoding.UTF8;
                // text or html
                myMail.IsBodyHtml = true;
                SendGridMail(myMail);
                ViewData["ConfirmMessage"] = "Thank you for signing up with us!";

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ViewData["ConfirmMessage"] = "The sign up has failed, please try again!";
                //throw;
            }

            return View("Signup");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public static void SendMail(MailMessage Message)
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.googlemail.com";
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(
                "illumonyContact@gmail.com",
                "Support@423");
            client.Send(Message);
        }

        public void SendGridMail(MailMessage Message)
        {
            //SmtpClient client = new SmtpClient();
            //client.Host = "smtp.googlemail.com";
            //client.Port = 587;
            //client.UseDefaultCredentials = false;
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //client.EnableSsl = true;
            //client.Credentials = new NetworkCredential(
            //    "illumonyContact@gmail.com",
            //    "Support@423");
            //client.Send(Message);


            // Retrieve the API key from the environment variables. See the project README for more info about setting this up.
            var apiKey = "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"; // Environment.GetEnvironmentVariable("sendGridApiKey"); //Config["sendGridApiKey"]; //

            var client = new SendGridClient(apiKey);

            // Send a Single Email using the Mail Helper
            var from = new EmailAddress(Message.From.Address, Message.From.DisplayName);
            var subject = Message.Subject;
            var to = new EmailAddress(Message.To[0].Address, Message.To[0].DisplayName);
            var plainTextContent = ""; //Message.Body;
            var htmlContent = Message.Body;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            var response = client.SendEmailAsync(msg);
        }
    }
}
