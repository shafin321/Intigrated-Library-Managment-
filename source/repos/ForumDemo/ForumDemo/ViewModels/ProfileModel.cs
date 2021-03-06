﻿using ForumDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumDemo.ViewModels
{
	public class ProfileModel
	{
		public string UserId { get; set; }
		public string Email { get; set; }
		public string UserName { get; set; }
		public string UserRating { get; set; }
		public string ProfileImageUrl { get; set; }
		public bool IsAdmin  { get; set; }

		public DateTime MemberSince { get; set; }
		public IForum ImageUpload { get; set; }
	}
}
