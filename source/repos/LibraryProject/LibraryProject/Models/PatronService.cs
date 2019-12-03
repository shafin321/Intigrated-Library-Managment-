using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryProject.Models
{
	public class PatronService : IPatron

	{
		private readonly LibraryDbContext _context;

		public PatronService(LibraryDbContext context)
		{
			_context = context;
		}
		public void Add(Patron newPatron)
		{
			_context.Add(newPatron);
			_context.SaveChanges();
		}

		public IEnumerable<Patron> GetAll()
		{
			return _context.Patrons.Include(p => p.LibraryCard).Include(p => p.HomeLibraryBranch);
		}

		public Patron GetById(int id)
		{
			return _context.Patrons.Include(p => p.LibraryCard).Include(p => p.HomeLibraryBranch).
				FirstOrDefault(p => p.Id == id);
		}

		public Checkout GetCheckoutByPatronId(int patronId)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<CheckoutHistory> GetCheckoutHistories(int patronId)
		{
			var cardId = _context.Patrons.
				Include(p => p.LibraryCard).
				FirstOrDefault(p => p.Id == patronId).LibraryCard.Id;

			return _context.CheckoutHistories.Include(c => c.LibraryCard).
				Include(c => c.LibraryAsset).Where(c => c.LibraryCard.Id == cardId).
				OrderByDescending(c => c.CheckedOut);
		}

		public IEnumerable<Checkout> GetCheckouts(int patronId)
		{
			var cardId = _context.Patrons.Include(p => p.LibraryCard)
				.FirstOrDefault(p => p.Id == patronId).LibraryCard.Id;

			return _context.Checkouts.Include(c => c.LibraryCard).
				Include(c => c.LibraryAsset).Where(c => c.LibraryCard.Id == cardId);
				
		}

		public Hold GetHoldById(int patronId)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Hold> GetHolds(int patronId)
		{
			var cardId = _context.Patrons.
				Include(p => p.LibraryCard).
				FirstOrDefault(p => p.Id == patronId).LibraryCard.Id;

			return _context.Holds.Include(h => h.LibraryCard)
				.Include(h => h.LibraryAsset).Where(h => h.LibraryCard.Id == cardId)
				.OrderByDescending(h=>h.HoldPlaced);
		}
	}
}
