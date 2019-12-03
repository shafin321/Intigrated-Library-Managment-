﻿using LibraryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryProject.ViewModel
{
	public class AssetIndexListingModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string DeweyCallNumber { get; set; }
		public string Type { get; set; }
		public Status Status { get; set; }
		public string AuthorOrDirector { get; set; }
		public string ImageUrl { get; set; }
		public int NumberOfCopies { get; set; }
		public virtual LibraryBranch Location { get; set; }
	}
}
