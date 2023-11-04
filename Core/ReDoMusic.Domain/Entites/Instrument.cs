using System;
using ReDoMusic.Domain.Common;
using ReDoMusic.Domain.Enums;

namespace ReDoMusic.Domain.Entites
{
	public class Instrument : EntityBase<Guid>
	{
		public string Name { get; set; }
		public Brand Brand { get; set; }
        public string Model { get; set; }
        public Color Color { get; set; }
        public DateTime? ProductionYear { get; set; }
        public decimal Price { get; set; }
        public bool IsInBasket { get; set; }
        public bool Starred { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}

