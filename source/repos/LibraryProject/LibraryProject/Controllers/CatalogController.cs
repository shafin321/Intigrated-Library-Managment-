using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryProject.Models;
using LibraryProject.ViewModel;

namespace LibraryProject.Controllers
{
	public class CatalogController : Controller
	{
		private readonly ILibraryAsset _libraryAsset;
		private readonly ICheckOut _checkout;
		public CatalogController(ILibraryAsset libraryAsset,ICheckOut checkOut )
		{
			_libraryAsset = libraryAsset;
			_checkout = checkOut;
		}
		public IActionResult Index()
		{
			IEnumerable<LibraryAsset> model = _libraryAsset.GetAll();
			var listingAsset = model.Select(result => new AssetIndexListingModel
			{
				Id = result.Id,
				ImageUrl = result.ImageUrl,
				AuthorOrDirector = _libraryAsset.GetAuthorOrDirector(result.Id),
				Location=result.Location,
				Title=result.Title,
				DeweyCallNumber=_libraryAsset.GetDeweyIndex(result.Id)
			  
		} );

			return View(listingAsset);

		}
				
						
		
		public IActionResult Details(int id)
		{
			var asset = _libraryAsset.getById(id);
			var currentHolds = _checkout.GetCurrentHolds(id).Select(a => new AssetHoldModel
			{
				HoldPlaced = _checkout.GetCurrentHoldPlaced(a.Id),
				PatronName = _checkout.GetCurrentHoldPatron(a.Id)
			});

			var model = new AssetDetailViewModel
			{
				AssetId = id,
				Title = asset.Title,
				Type = _libraryAsset.GetType(id),
				Year = asset.Year,
				Cost = asset.Cost,
				Status = asset.Status.Name,
				ImageUrl = asset.ImageUrl,
				AuthorOrDirector = _libraryAsset.GetAuthorOrDirector(id),
	
				Dewey = _libraryAsset.GetDeweyIndex(id),
				CheckoutHistory = _checkout.GetCheckoutHistory(id),
			
				Isbn = _libraryAsset.GetIsbn(id),
				LatestCheckout = _checkout.GetLatestCheckout(id),
				CurrentHolds = currentHolds,
				PatronName = _checkout.GetCurrentPatron(id)
			};

			return View(model);
		}

		public IActionResult Checkout(int id)
		{
			var asset = _libraryAsset.getById(id);

			var model = new CheckoutViewModel
			{
				AssetId = id,
				ImageUrl = asset.ImageUrl,
				Title = asset.Title,
				LibraryCardId = "",
				IsCheckedOut = _checkout.IsCheckedOut(id)
			};
			return View(model);
		}

		public IActionResult CheckIn(int id)
		{
			_checkout.CheckInItem(id);
			return RedirectToAction("Details", new { id = id });
		}
		public IActionResult Hold(int id)
		{
			var asset = _libraryAsset.getById(id);

			var model = new CheckoutViewModel
			{
				AssetId = id,
				ImageUrl = asset.ImageUrl,
				Title = asset.Title,
				LibraryCardId = "",
				HoldCount = _checkout.GetCurrentHolds(id).Count()
			};
			return View(model);
		}

		

		public IActionResult MarkLost(int id)
		{
			_checkout.MarkLost(id);
			return RedirectToAction("Detail", new { id });
		}

		public IActionResult MarkFound(int id)
		{
			_checkout.MarkFound(id);
			return RedirectToAction("Detail", new { id });
		}

		[HttpPost]
		public IActionResult PlaceCheckout(int assetId, int libraryCardId)
		{
			_checkout.CheckoutItem(assetId, libraryCardId);
			return RedirectToAction("Details", new { id = assetId });
		}
		[HttpPost]
		public IActionResult PlaceHold(int assetId, int libraryCardId)
		{
			_checkout.PlaceHold(assetId, libraryCardId);
			return RedirectToAction("Details", new { id = assetId });
		}


	}
}

