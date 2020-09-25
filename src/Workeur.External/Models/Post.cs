using System;

namespace Workeur.External.Models
{
	public class Post
	{
		public string Title { get; set; }
		
		public string Author { get; set; }
		
		public string Description { get; set; }
		
		public string Link { get; set; }

		public int Comments { get; set; }
	}
}