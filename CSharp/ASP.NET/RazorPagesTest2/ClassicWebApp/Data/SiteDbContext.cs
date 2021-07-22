using System;
using Microsoft.EntityFrameworkCore;

namespace ClassicWebApp.Data
{
	public class Visitor
	{
		public string Id { get; set; }

		public int Frequency { get; set; }

		public DateTime Recent { get; set; }
	}

	public class SiteDbContext : DbContext
	{
		public SiteDbContext()
		{
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("FileName=site.db");
		}

		public DbSet<Visitor> Visitors { get; set; }
	}
}
          
