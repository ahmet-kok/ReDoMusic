using System;
using ReDoMusic.Domain.Common;

namespace ReDoMusic.Domain.Entites
{
    public class Brand : EntityBase<Guid>
	{
        public string Name { get; set; }
        public string DisplayText { get; set; }
        public string Address { get; set; }
	}
}

