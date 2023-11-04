using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReDoMusic.Persistence;
using ReDoMusic.Persistence.Context;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReDoMusic.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ReDoMusicDbContext _context;

        public HomeController()
        {
            _context = new();
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            Configurations.GetString("ConnectionStrings:PostgreSQL");
            var instruments = _context.Instruments.Include(x => x.Brand).ToList();
            return View(instruments);
        }
    }
}

