using System;
using ReDoMusic.Domain.Common;
using ReDoMusic.Domain.Enums;

namespace ReDoMusic.Domain.Entites
{
	public class Instrument : EntityBase<Guid>
	{
		public String Name { get; set; }
		public String Brand { get; set; }
        public String Model { get; set; }
        public Color Color { get; set; }
        public DateTime? ProductionYear { get; set; }
        public decimal Price { get; set; }
        public Instrument()
		{
		}
	}
}

