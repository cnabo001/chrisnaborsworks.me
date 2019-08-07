//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;

//namespace ChrisNaborsWorks.Models
//{
//    public class VideoContext : IdentityDbContext<ChrisNaborsWorksUser>
//	{

//		private IConfigurationRoot _Vconfig;

//		public VideoContext(IConfigurationRoot Vconfig, DbContextOptions options) : base(options)
//		{
//			_Vconfig = Vconfig;
//		}

//		public DbSet<Likes> Likes { get; set; }
//		public DbSet<Store> Store { get; set; }

//		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//		{
//			base.OnConfiguring(optionsBuilder);
//			optionsBuilder.UseSqlServer(_Vconfig["ConnectionStrings:ContextConnection"]);
//		}
//	}
//}
