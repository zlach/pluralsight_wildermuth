using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using DutchTreat.Data.Entities;

namespace DutchTreat.Data
{
	public class DutchContext : IDutchContext
	{
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }
        public IClientSessionHandle Session { get; set; } // TODO figure out what this is

        //public IMongoCollection<Product> Products { get; set; }
        //public IMongoCollection<Order> Orders { get; set; }

        public DutchContext(IOptions<DutchTreatDatabaseSettings> configuration)
        {
            _mongoClient = new MongoClient(configuration.Value.ConnectionString);
            _db = _mongoClient.GetDatabase(configuration.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }
    }
}

