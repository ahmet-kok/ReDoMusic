﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReDoMusic.Domain.Entites;
using ReDoMusic.Domain.Enums;
using ReDoMusic.Persistence.Context;

namespace ReDoMusic.MVC.Controllers
{
    public class InstrumentController : Controller
    {
        private readonly ReDoMusicDbContext _context;

        public InstrumentController()
        {
            _context = new ReDoMusicDbContext();
        }

        public IActionResult Index()
        {
            var instruments = _context.Instruments.ToList();

            return View(instruments);
        }

        [HttpGet]
        public IActionResult AddInstrument()
        {
            var brands = _context.Brands.ToList();
            return View(brands);
        }

        
        [HttpPost]
        public IActionResult AddInstrument(string instrumentName, string brandName,string instrumentModel, Color instrumentColor, decimal price)
        {
            var brand = _context.Brands.Where(brand => brand.Name == brandName).FirstOrDefault();
            var instrument = new Instrument()
            {
                Name = instrumentName,
                Brand = brand,
                Model = instrumentModel,
                Color = instrumentColor,
                Price = price,
                IsInBasket = false,
                Starred = false,
                Comments = null,
            };

            _context.Add(instrument);
            _context.SaveChanges();

            return RedirectToAction("index");
        }


        [HttpGet]
        public IActionResult DeleteInstrument(string id)
        {
            var instrument = _context.Instruments.FirstOrDefault(x => x.Id == Guid.Parse(id));

            if (instrument != null)
            {
                _context.Instruments.Remove(instrument);

                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }
    }
}
