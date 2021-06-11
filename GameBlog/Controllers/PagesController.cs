using System;
using System.Threading.Tasks;
using GameBlog.Data;
using GameBlog.Models;
using GameBlog.ViewModel;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace GameBlog.Controllers
{
    public class PagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public PagesController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public IActionResult Contact()
        {
            var contactFormViewModel = new ContactFormViewModel();
            return View(contactFormViewModel);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Contact([FromForm] ContactFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var message = new ContactMessage()
                {
                    Email = model.Email,
                    Message = model.Message,
                    Name = model.Name,
                    Subject = model.Subject,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _context.ContactMessages.Add(message);
                await _context.SaveChangesAsync();

                ViewData["contactMessage"] = "success";
            }
            else
            {
                ViewData["contactMessage"] = "error";
                return View(model);
            }


            var mailMessage = new MimeMessage();

            var to = _configuration["EmailService:To"];
            var host = _configuration["EmailService:Host"];
            var sender = _configuration["EmailService:Sender"];
            var password = _configuration["EmailService:Password"];

            mailMessage.From.Add(new MailboxAddress("Game Blog", sender));
            mailMessage.To.Add(new MailboxAddress("Admin Game Blog", to));
            mailMessage.Subject = model.Subject;

            mailMessage.Body = new TextPart()
            {
                Text = ":::from: " + model.Email + "\n:::name: " + model.Name + "\n:::message: " + model.Message
            };


            var c = new SmtpClient();

            await c.ConnectAsync(host, 465, true);
            await c.AuthenticateAsync(sender, password);
            await c.SendAsync(mailMessage);
            await c.DisconnectAsync(true);


            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Title"] = "Privacy page";
            return View();
        }


        public IActionResult Newsletter()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> NewsLetters([FromForm] string email)
        {
            try
            {
                var newsletter = new Newsletter()
                {
                    Email = email,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _context.Newsletters.Add(newsletter);
                await _context.SaveChangesAsync();

                return RedirectToAction("Newsletter");
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}