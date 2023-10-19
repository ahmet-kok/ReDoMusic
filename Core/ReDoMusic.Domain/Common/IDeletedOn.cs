using System;
namespace ReDoMusic.Domain.Common
{
	public interface IDeletedOn
	{
        public DateTime? DeletedOn { get; set; }
	}
}

