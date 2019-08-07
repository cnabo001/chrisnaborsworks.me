using ChrisNaborsWorks.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChrisNaborsWorks.Models
{
	public interface ICNWRepository
	{
		IEnumerable<Likes> GetAllLikes();

		IEnumerable<Likes> GetLikesByUser(string name);
		Likes GetCryptoByName(string cryptoName);

		void AddLikes(Likes likes);

		
		Task<bool> SaveChangesAsync();

		void AddStore(string cryptoName, Store newStore, string userName);


		IEnumerable<CryptoCurrencies> GetCryptoCurrencies();
		Likes GetUserCryptoByName(string cryptoName, string name);
		void AddUser(RegisterViewModel register);
	}
}