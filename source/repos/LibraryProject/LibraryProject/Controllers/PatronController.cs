using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryProject.Models;
using LibraryProject.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers
{
    public class PatronController : Controller
    {
		private readonly IPatron _patron;

		public PatronController(IPatron patron)
		{
			_patron = patron;
		}
        public IActionResult Index()
        {
			var allpatron = _patron.GetAll();

			var model = allpatron.Select(patron => new PatronDetailModel
			{
				Id = patron.Id,
				FirstName = patron.FirstName,
				LastName = patron.LastName,
				LibraryCardId = patron.LibraryCard.Id,
				OverdueFees = patron.LibraryCard.Fees,
				HomeLibrary = patron.HomeLibraryBranch.Name,
		
	 			});

            return View(model);
        }
		public ActionResult Detail(int id)
		{
			var patron = _patron.GetById(id);
			var model = new PatronDetailModel
			{
				Id = patron.Id,
				LastName = patron.LastName ?? "No Last Name Provided",
				FirstName = patron.FirstName ?? "No First Name Provided",
				Address = patron.Address ?? "No Address Provided",
				HomeLibrary = patron.HomeLibraryBranch?.Name ?? "No Home Library",
				MemberSince = patron.LibraryCard?.Created,
				OverdueFees = patron.LibraryCard?.Fees,
				LibraryCardId = patron.LibraryCard?.Id,
				Telephone = string.IsNullOrEmpty(patron.Telephone) ? "No Telephone Number Provided" : patron.Telephone,
				AssetsCheckedOut = _patron.GetCheckouts(id) ?? new List<Checkout>(),
				CheckoutHistory=_patron.GetCheckoutHistories(id),
				Holds=_patron.GetHolds(id),
			};

			return View(model);

		}
    }
}