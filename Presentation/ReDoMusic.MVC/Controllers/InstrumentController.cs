using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReDoMusic.Domain.Entites;
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
            return View();
        }

        [HttpPost]
        public IActionResult AddInstrument(string instrumentName, string brandName, string brandDisplayText, string brandAddress, string instrumentModel, Color instrumentColor, decimal price)
        {
            var brand = new Brand()
            {
                Id = Guid.NewGuid(),
                Name = brandName,
                Address = brandAddress,
                DisplayText = brandDisplayText,
                CreatedOn = DateTime.UtcNow,
            };

            var instrument = new Instrument()
            {
                Name = instrumentName,
                Brand = brand,
                Model = instrumentModel,
                Color = instrumentColor,
                Price = price,
                IsInBasket = true,
                Starred = false,
                Comments = null,
            };

            _context.Add(instrument);
            _context.SaveChanges();

            return View();
        }


        [HttpGet]
        public IActionResult DeleteInstrument(string id)
        {
            var instrument = _context.Instruments.Include(x => x.Brand).FirstOrDefault(x => x.Id == Guid.Parse(id));

            if (instrument != null)
            {
                _context.Instruments.Remove(instrument);

                if (instrument.Brand != null)
                {
                    _context.Brands.Remove(instrument.Brand);
                }

                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }
    }
}
