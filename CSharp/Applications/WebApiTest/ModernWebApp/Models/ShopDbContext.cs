using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ModernWebApp.Models
{
	[Table("OrderDetail")]
	public class Order
	{
		[Column("OrderNo")]
		public int Id { get; set; }

		public DateTime OrderDate { get; set; }

		public string CustomerId { get; set; }

		public int ProductNo { get; set; }

		public int Quantity { get; set; }
	}

	public class Customer
	{
		public string CustomerId { get; set; }

		public ICollection<Order> Orders { get; set; }
	}

	public class Counter
	{
		public string Id { get; set; }

		public int SeedValue { get; set; }
		
		public int CurrentValue { get; set; }
	}

	public class ShopDbContext : DbContext
	{
		public DbSet<Order> Orders { get; set; }
		
		public DbSet<Customer> Customers { get; set; }
		
		public DbSet<Counter> Counters { get; set; }

		public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) {}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Customer>()
				.ToTable("CustomerInfo")
				.Property(e => e.CustomerId)
				.HasColumnName("UserName");
		}

	}
}


