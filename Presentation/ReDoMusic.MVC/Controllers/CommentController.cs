using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReDoMusic.Domain.Entites;
using ReDoMusic.MVC.Models;
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
            CommentViewModel commentViewModel = new CommentViewModel();

            if (id == null)
            {
                var comments = _context.Comments.Include(x => x.Instrument).ToList();
                commentViewModel.Comments = comments;
                return View(commentViewModel);
            }
            else
            {
                var comments = _context.Comments.Include(x => x.Instrument).Where(x => x.Instrument.Id == Guid.Parse(id)).ToList();
                commentViewModel.Comments = comments;
                commentViewModel.Instrument = _context.Instruments.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();
                return View(commentViewModel);
            }
        }

        public IActionResult Comment(string id)
        {
            var comments = _context.Comments.Include(x => x.Instrument).Where(x => x.Id == Guid.Parse(id)).ToList();
            return View(comments);
        }

        [HttpGet]
        public IActionResult AddComment(string id)
        {
            if (id == null)
            {
                return RedirectToAction("index");
            }
            var instrument = _context.Instruments.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();

            return View(instrument);
        }

        [HttpPost]
        public IActionResult AddComment(string InstrumentId, string commentText)
        {
            var instrument = _context.Instruments.Where(x => x.Id == Guid.Parse(InstrumentId)).FirstOrDefault();
            var comment = new Comment()
            {
                Instrument = instrument,
                Id = Guid.NewGuid(),
                Owner = "User",
                Text = commentText,
                CreatedOn = DateTime.UtcNow,
            };
            _context.Add(comment);
            _context.SaveChanges();
            return RedirectToAction("index");
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

