using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryProject.Models
{
	public class LibraryAssetService : ILibraryAsset
	{
		private LibraryDbContext _context;

		public LibraryAssetService(LibraryDbContext context)
		{
			_context = context;
		}
		public LibraryAsset Add(LibraryAsset newAsset)
		{
			_context.Add(newAsset);
			_context.SaveChanges();
			return newAsset;
			 
		}

		public IEnumerable<LibraryAsset> GetAll()
		{
			return _context.LibraryAssets.Include(a => a.Location).
				Include(a => a.Status);
		}

		public string GetAuthorOrDirector(int id)
		{
			var IsBook = _context.LibraryAssets.OfType<Book>()
				.Where(asset => asset.Id == id).Any();

			var isVideo = _context.LibraryAssets.OfType<Video>().
				Where(asset => asset.Id == id).Any();
			return IsBook ?
				_context.Books.FirstOrDefault(book => book.Id == id).Author :
				_context.Videos.FirstOrDefault(video => video.Id == id).Director ?? "Unknown";
		}

		public LibraryAsset getById(int id)
		{
			return _context.LibraryAssets.Include(asset => asset.Location).
				Include(a => a.Status).
				FirstOrDefault(asset => asset.Id == id);
		}

		public LibraryBranch GetcurrentLocation(int id)
		{
			return _context.LibraryBranches.FirstOrDefault(a => a.Id == id);
		}

		public string GetDeweyIndex(int id)
		{
			if (_context.Books.Any(b => b.Id == id))
			{
				return _context.Books.FirstOrDefault(b => b.Id == id).DeweyIndex;
			}
			else
				return "";
		}

		public string GetIsbn(int id)
		{
			if (_context.Books.Any())
			{
				return _context.Books.FirstOrDefault(b => b.Id == id).ISBN;

			}
			else
				return "";
		}

		public string GetType(int id)
		{
			// Hack
			var book = _context.LibraryAssets
				.OfType<Book>().SingleOrDefault(a => a.Id == id);
			return book != null ? "Book" : "Video";
		}
	}
}
