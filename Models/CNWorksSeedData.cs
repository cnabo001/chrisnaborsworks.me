using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ChrisNaborsWorks.Models
{
	public class CNWorksSeedData
	{
		private DataContext _context;
		private UserManager<ChrisNaborsWorksUser> _userManager;
		public CNWorksSeedData(DataContext context, UserManager<ChrisNaborsWorksUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}


		public async Task ConfimSeedData()
		{

			if (await _userManager.FindByEmailAsync("cnabo001@yahoo.com") == null)
			{
				var user = new ChrisNaborsWorksUser()
				{
					UserName = "ChrisNabors",
					Email = "cnabo001@yahoo.com",
					//MemberName = "Creator"
				};

				await _userManager.CreateAsync(user, "$pass20yards");

			}



			if (!_context.Likes.Any())
			{
				var AdminLikes = new Likes()
				{

					
					CryptoName = "Bitcoin",
					VidName = "youtube.com/watch?v=SNssKmeXrGs",
					UserName = "ChrisNabors",
				
					Store = new List<Store>
					{

						new Store() {CryptoName = "Ethereum", VidName = "youtube.com/watch?v=gjwr-7PgpN8", addDate = DateTime.Now},
						new Store() {CryptoName = "Ripple", VidName = "youtube.com/watch?v=jNsPJsXinfc", addDate = DateTime.Now},
						new Store() {CryptoName = "LiteCoin", VidName = "youtube.com/watch?v=G9iE83IAxY", addDate = DateTime.Now},
						new Store() {CryptoName = "EthereumClassic", VidName = "youtube.com/watch?v=SQZB3pAhjP4", addDate = DateTime.Now},
						new Store() {CryptoName = "Cardano", VidName = "youtube.com/watch?v=Do8rHvr65ZA", addDate = DateTime.Now}


					}
				};

				
				_context.Likes.Add(AdminLikes);
				_context.Store.AddRange(AdminLikes.Store);
				


				await _context.SaveChangesAsync();
			}
			
		}
	}
}
