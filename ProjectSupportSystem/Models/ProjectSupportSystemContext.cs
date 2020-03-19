using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ProjectSupportSystem.Models;

namespace ProjectSupportSystem.Models
{
	public class ProjectSupportSystemContext : DbContext
	{
		public ProjectSupportSystemContext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<Support> Supports { get; set; }
		public DbSet<SupportElement> SupportElements { get; set; }
		public DbSet<SupportSupElement> SupportSupElements { get; set; } 
	}
}
