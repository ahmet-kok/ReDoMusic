using System;
using ReDoMusic.Domain.Entites;

namespace ReDoMusic.MVC.Models
{
	public class CommentViewModel
	{
		public List<Comment>? Comments { get; set; }
		public Instrument? Instrument { get; set; }
	}
}

