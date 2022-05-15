using System;
using DutchTreat.Data.Entities;
using MongoDB.Driver;

namespace DutchTreat.Data
{
	public interface IDutchContext
	{
		IMongoCollection<T> GetCollection<T>(string name);

		IClientSessionHandle Session { get; set; }

		//IMongoCollection<Product> Products { get; set; }
		//IMongoCollection<Order> Orders { get; set; }
	}
}
