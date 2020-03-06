using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSupportSystem.Data
{
	public class ProjectSupportSystemContext : DbContext
	{
		public ProjectSupportSystemContext(DbContextOptions options) : base(options)
		{
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=.;Database=ProjectSupportSystemDB;User Id=sa;Password=123");
		}
		public DbSet<Support> Supports { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<SupportElement> SupportElements { get; set; }
		public DbSet<SupportProperty> SupportProperties { get; set; }
		public DbSet<SupPropSupElem> SupPropSupElems { get; set; } 
	}
}
