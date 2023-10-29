using System;
using ReDoMusic.Domain.Common;

namespace ReDoMusic.Domain.Entites
{
	public class Comment : EntityBase<Guid>
    {
		public string Owner { get; set; }
		public string Text { get; set; }
		public Instrument Instrument { get; set; }
    }
}

