using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryProject.Models
{
	public interface IPatron
	{
		Patron GetById(int id);
		IEnumerable<Patron> GetAll();
		void Add(Patron newPatron);

		IEnumerable<CheckoutHistory> GetCheckoutHistories(int patronId);
		Hold GetHoldById(int patronId);
		IEnumerable<Hold> GetHolds(int patronId);
		IEnumerable<Checkout> GetCheckouts(int patronId);
		Checkout GetCheckoutByPatronId(int patronId);





	}
}
