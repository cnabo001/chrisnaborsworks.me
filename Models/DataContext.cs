using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChrisNaborsWorks.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ChrisNaborsWorks.Models
{
	public class DataContext : IdentityDbContext<ChrisNaborsWorksUser>
	{
		private IConfigurationRoot _config;

		public DataContext()
		{
		}

		public DataContext(IConfigurationRoot config, DbContextOptions options) : base(options)
		{
			_config = config;
		}

		

		public DbSet<Likes> Likes { get; set; }
		public DbSet<Store> Store { get; set; }
		public DbSet<RegisterViewModel> Register {get; set;}

		public virtual DbSet<CryptoCurrencies> CryptoCurrencies { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer(_config["ConnectionStrings:1and1"]);
		}
	}
}
