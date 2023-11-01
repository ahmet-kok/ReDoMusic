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
    public class BrandController : Controller
    {
        private readonly ReDoMusicDbContext _context;
        public BrandController()
        {
            _context = new();
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var brands = _context.Brands.ToList();
            return View(brands);
        }

        [HttpGet]
        public IActionResult AddBrand()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBrand(string brandName, string brandDisplayText, string brandAddress)
        {
            var brand = new Brand()
            {
                Id = Guid.NewGuid(),
                Name = brandName,
                Address = brandAddress,
                DisplayText = brandDisplayText,
                CreatedOn = DateTime.UtcNow,
            };
            _context.Add(brand);
            _context.SaveChanges();
            return View();
        }
        [HttpPost]
        public IActionResult UpdateBrand(string user_id, string name, string displaytext, string address)
        {

            var brand = _context.Brands.Where(x => x.Id == Guid.Parse(user_id)).FirstOrDefault();

            brand.Name = name;
            brand.Address = address;
            brand.DisplayText = displaytext;
            brand.ModifiedOn = DateTime.UtcNow;
       
            //_context.Update(brand);
            _context.SaveChanges();
            return RedirectToAction("index");
        }


        [HttpGet]
        public IActionResult DeleteBrand(string id)
        {
            var brand = _context.Brands.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();
            _context.Brands.Remove(brand);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}

