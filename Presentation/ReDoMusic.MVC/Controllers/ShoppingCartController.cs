using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReDoMusic.Domain.Entites;
using ReDoMusic.Domain.Enums;
using ReDoMusic.Persistence.Context;

namespace ReDoMusic.MVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ReDoMusicDbContext _context;

        public ShoppingCartController()
        {
            _context = new();
        }

        /*
         //var shoppingCart = _context.ShoppingCarts.OrderBy(x => x.Id).Last();
            //var shoppingCart = _context.ShoppingCarts.Where(x=> x.)
            var cart = _context.ShoppingCarts.Where(x => x.Id == Guid.Parse("123e4567-e89b-12d3-a456-426614174000")).FirstOrDefault();

            //var instruments = _context.Instruments.Where(x => x.Shopping == "123e4567-e89b-12d3-a456-426614174000").FirstOrDefault();
            Instrument instrument = new Instrument
            {
                Id = Guid.NewGuid(), // Assign a unique identifier
                Name = "Example Instrument",
                Brand = new Brand
                {
                    Id = Guid.NewGuid(), // Assign a unique identifier for the Brand
                    Name = "Example Brand",
                    DisplayText = "Example Display Text",
                    Address = "123 Example Street"
                },
                Model = "Example Model",
                Color = Domain.Enums.Color.Red, // Assuming Color is an enum
                ProductionYear = new DateTime(2023, 1, 1),
                Price = 999.99m
            };

            Instrument instrument2 = new Instrument
            {
                Id = Guid.NewGuid(), // Assign a unique identifier
                Name = "Example Instrument",
                Brand = new Brand
                {
                    Id = Guid.NewGuid(), // Assign a unique identifier for the Brand
                    Name = "Example Brand",
                    DisplayText = "Example Display Text",
                    Address = "123 Example Street"
                },
                Model = "Example Model",
                Color = Domain.Enums.Color.Red, // Assuming Color is an enum
                ProductionYear = new DateTime(2023, 1, 1),
                Price = 999.99m
            };

            var instruments = new List<Instrument> { instrument, instrument2 };

            //shoppingCart.Items.Add(instrument);
         */

        [HttpGet]
        public IActionResult Index()
        {
            var instruments = _context.Instruments.Include(x => x.Brand).Where(x => x.IsInBasket == true).ToList();
            return View(instruments);
        }

        [HttpGet]
        public IActionResult AddCartItem(string id)
        {
            //var brand2 = new Brand
            //{
            //    Id = Guid.NewGuid(), // Assign a unique identifier for the Brand
            //    Name = "Example Brand",
            //    DisplayText = "Example Display Text",
            //    Address = "123 Example Street"
            //};

            //Instrument instrument = new()
            //{
            //    Id = Guid.NewGuid(),
            //    Name = name,
            //    Brand = brand2,
            //    Price = price,
            //    Color = color,
            //    Model = model
            //};



            //var cart = _context.ShoppingCarts.Where(x => x.Id == Guid.Parse("123e4567-e89b-12d3-a456-426614174000")).FirstOrDefault();

            var instrument = _context.Instruments.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();

            //if (instrument==null)
            //    return BadRequest();

            //ShoppingCart shoppingCart = new ShoppingCart();
            //shoppingCart.Items = new List<Instrument>
            //{
            //    instrument
            //};

            //_context.SaveChanges();
            //_context.ShoppingCarts.Add(shoppingCart);

            instrument.IsInBasket = true;
            _context.SaveChanges();

            return RedirectToAction("index","home");
        }

        [HttpGet]
        public IActionResult DeleteCartItem(string id)
        {
            var instrument = _context.Instruments.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();

            instrument.IsInBasket = false;
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
