using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReDoMusic.Domain.Entities;
using ReDoMusic.Persistence.Context;

namespace ReDoMusic.MVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly ReDoMusicDbContext _context;
        public ContactController()
        {
            _context = new();
        }
        public ActionResult Index()
        {
            var contact = _context.Contacts.Where(x => x.IsResolved == false).ToList();

            return View(contact);
        }
        [HttpGet]
        public IActionResult SubmitContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitContact(string contactFirstName, string contactLastName, string contactEmail, string contactSubject)
        {
            var contact = new Contact()
            {
                FirstName = contactFirstName,
                LastName = contactLastName,
                Email = contactEmail,
                Subject = contactSubject,
                CreatedOn = DateTime.UtcNow,
            };
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return View();
        }
        [HttpGet]
        public IActionResult DeleteContact(string id)
        {
            var contact = _context.Contacts.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult ResultContact(string id)
        {
            var contact = _context.Contacts.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();
            contact.IsResolved = true;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
