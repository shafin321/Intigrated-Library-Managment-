using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryProject.Models
{
	public interface ILibraryAsset
	{
		IEnumerable<LibraryAsset> GetAll();
		LibraryAsset getById(int id);
		LibraryAsset Add(LibraryAsset newAsset);
		string GetAuthorOrDirector(int id);
		string GetDeweyIndex(int id);
		string GetType(int id);
		string GetIsbn(int id);
		LibraryBranch GetcurrentLocation(int id);

	}
}
