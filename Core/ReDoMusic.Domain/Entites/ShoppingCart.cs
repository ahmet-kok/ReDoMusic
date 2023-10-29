using ReDoMusic.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReDoMusic.Domain.Entites
{
    public class ShoppingCart : EntityBase<Guid>
    {
        public List<Instrument> Items { get; set; }

        public ShoppingCart()
        {
            Items = new List<Instrument>(); 
        }
    }
}
