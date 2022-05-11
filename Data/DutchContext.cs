using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DutchTreat.Data
{
	public class DutchContext : IDutchContext
	{
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }
        public IClientSessionHandle Session { get; set; }

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

