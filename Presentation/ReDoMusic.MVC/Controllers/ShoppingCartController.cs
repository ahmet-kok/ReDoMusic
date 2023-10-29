using Microsoft.AspNetCore.Mvc;
using ReDoMusic.Domain.Entites;
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

        public IActionResult Index()
        {
            var shoppingCart = _context.ShoppingCarts.FirstOrDefault();

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


            shoppingCart.Items.Add(instrument);
            return View(shoppingCart);
        }

        [HttpGet]
        public IActionResult AddBrand()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCartItem(string name, string brand, string brandAddress)
        {
            //var brand = new Instrument()
            //{
            //    Id = Guid.NewGuid(),
            //    Name = brandName,
            //    Address = brandAddress,
            //    DisplayText = brandDisplayText,
            //    CreatedOn = DateTime.UtcNow,
            //};
            //_context.Add(brand);
            //_context.SaveChanges();
            return View();
        }
    }
}
