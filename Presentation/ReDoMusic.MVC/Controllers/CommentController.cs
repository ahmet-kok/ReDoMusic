using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReDoMusic.Domain.Entites;
using ReDoMusic.Persistence.Context;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReDoMusic.MVC.Controllers
{
    public class CommentController : Controller
    {
        private readonly ReDoMusicDbContext _context;
        public CommentController()
        {
            _context = new();
        }
        // GET: /<controller>/
        public IActionResult Index(string id)
        {


            if (id == null)
            {
                var comments = _context.Comments.Include(x => x.Instrument).ToList();
                return View(comments);
            }
            else
            {
                var comments = _context.Comments.Include(x => x.Instrument).Where(x => x.Id == Guid.Parse(id)).ToList();
                return View(comments);
            }
        }

        public IActionResult Comment(string id)
        {
            var comments = _context.Comments.Include(x => x.Instrument).Where(x => x.Id == Guid.Parse(id)).ToList();
            return View(comments);
        }

        [HttpGet]
        public IActionResult AddComment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddComment(string InstrumentId, string commentText)
        {
            var comment = new Comment()
            {
                Id = Guid.NewGuid(),
                Owner = "User",
                Text = commentText,
                CreatedOn = DateTime.UtcNow,
            };
            _context.Add(comment);
            _context.SaveChanges();
            return View();
        }

        [HttpGet]
        public IActionResult DeleteComment(string id)
        {
            var comment = _context.Comments.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();
            _context.Comments.Remove(comment);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}

