using ChrisNaborsWorks.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChrisNaborsWorks.Models
{
    public class CNWRepository : ICNWRepository
	{
		private DataContext _context;
		private ILogger<CNWRepository> _logger;
        public CNWRepository(DataContext context, ILogger<CNWRepository> logger)
		{

			_context = context;
			_logger = logger;

		}

		public void AddLikes(Likes likes)
		{
			_context.Add(likes);
		}

		public void AddUser(RegisterViewModel register)
		{
			
			_context.Register.Add(register);
		}


		public void AddStore(string cryptoName, Store newStore, string userName)
		{
			var crypto = GetUserCryptoByName(cryptoName, userName);

			if(crypto != null)
			{
				crypto.Store.Add(newStore);
				_context.Store.Add(newStore);
			}
		}

		public IEnumerable<Likes>GetAllLikes()
		{
			_logger.LogInformation("Getting all likes from database");
			return _context.Likes.ToList();
		}

		public Likes GetCryptoByName(string cryptoName)
		{
			return _context.Likes
				.Include(l => l.Store)
				.Where(l => l.CryptoName == cryptoName)
				.FirstOrDefault();
		}

		public IEnumerable<CryptoCurrencies>GetCryptoCurrencies()
		{
			return _context.CryptoCurrencies.ToList();
		}

		public IEnumerable<Likes> GetLikesByUser(string name)
		{
			return _context.Likes
				.Include(i => i.Store)
				.Where
				(u => u.UserName == name)
				.ToList();
		}

		public Likes GetUserCryptoByName(string cryptoName, string username)
		{
			return _context.Likes
				.Include(l => l.Store)
				.Where(l => l.CryptoName == cryptoName) 
				//&&(l => l.UserName = username)
				.FirstOrDefault();
		}

		public async Task<bool> SaveChangesAsync()
		{
			return (await _context.SaveChangesAsync()) > 0;
		}
    }
}
