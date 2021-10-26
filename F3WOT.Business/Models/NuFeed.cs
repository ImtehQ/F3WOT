using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;
using F3WOT.Business.Interfaces;

namespace F3WOT.Business.Models
{
	public class NuFeed : IFeed
	{
		public string Discription { get; set; }
		public string Url { get; set; }
		public DateTimeOffset LastUpdated { get; set; }
		public List<string> Links { get; set; }
		public DateTimeOffset Published { get; set; }
		public string Title { get; set; }
	}
}
