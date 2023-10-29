using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            var comments = _context.Comments.ToList();
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

