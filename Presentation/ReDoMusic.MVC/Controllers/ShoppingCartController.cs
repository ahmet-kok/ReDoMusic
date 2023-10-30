using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult Index()
        {
            var shoppingCart = _context.ShoppingCarts.FirstOrDefault();

            //Instrument instrument = new Instrument
            //{
            //    Id = Guid.NewGuid(), // Assign a unique identifier
            //    Name = "Example Instrument",
            //    Brand = new Brand
            //    {
            //        Id = Guid.NewGuid(), // Assign a unique identifier for the Brand
            //        Name = "Example Brand",
            //        DisplayText = "Example Display Text",
            //        Address = "123 Example Street"
            //    },
            //    Model = "Example Model",
            //    Color = Domain.Enums.Color.Red, // Assuming Color is an enum
            //    ProductionYear = new DateTime(2023, 1, 1),
            //    Price = 999.99m
            //};


            //shoppingCart.Items.Add(instrument);
            return View(shoppingCart);
        }

        [HttpGet]
        public IActionResult AddCartItem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCartItem(Guid id,string name, string brand, Color color, decimal price, string model)
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

            var instrument = _context.Instruments.Where(x => x.Id == id).FirstOrDefault();

            if (instrument==null)
                return BadRequest();

            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.Items.Add(instrument);

            _context.ShoppingCarts.Add(shoppingCart);
            _context.SaveChanges();

            return View();
        }
    }
}
