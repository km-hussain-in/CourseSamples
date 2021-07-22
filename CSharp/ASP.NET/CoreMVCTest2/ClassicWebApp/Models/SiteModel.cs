using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ClassicWebApp.Models
{
	public class Visitor
	{
		public string Id { get; set; }

		public int Frequency { get; set; }

		public DateTime Recent { get; set; }
	}

	public class SiteModel : IDisposable
	{
		private List<Visitor> visitors;

		public SiteModel()
		{
			if(File.Exists("site.doc"))
			{
				var ser = new XmlSerializer(typeof(List<Visitor>));
				using(var reader = File.OpenText("site.doc"))
					visitors = (List<Visitor>) ser.Deserialize(reader);
			}
			else
				visitors = new List<Visitor>();
		}

		public IEnumerable<Visitor> ReadVisitors() => visitors;
	
		public void WriteVisitor(string name)
		{
			var visitor = visitors.Find(e => e.Id == name);
			if(visitor == null)
			{
				visitor = new Visitor {Id = name};
				visitors.Add(visitor);
			}
			visitor.Frequency += 1;
			visitor.Recent = DateTime.Now;
		}

		public void Dispose()
		{
			var ser = new XmlSerializer(typeof(List<Visitor>));
			using(var writer = File.CreateText("site.doc"))
					ser.Serialize(writer, visitors);

		}
	}
}
