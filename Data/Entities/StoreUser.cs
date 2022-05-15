using System;
using Microsoft.AspNetCore.Identity;

namespace DutchTreat.Data.Entities
{
	public class StoreUser : IdentityUser
	{
		public StoreUser()
		{
		}
		public string FirstName { get; set; }
		public string LastName { get; set; }

	}
}

