using System;
using MongoDB.Driver;

namespace DutchTreat.Data
{
	public interface IDutchContext
	{
		IMongoCollection<T> GetCollection<T>(string name);
	}
}

