//using DutchTreat.Data;
//using DutchTreat.Data.Entities;
//using Microsoft.Extensions.Options;
//using MongoDB.Driver;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace DutchTreat.Services
//{
//    public class ProductsService
//    {
//        private readonly IMongoCollection<Product> _productsCollection;

//        public ProductsService(
//            IOptions<DutchTreatDatabaseSettings> dutchTreatDatabaseSettings)
//        {
//            var mongoClient = new MongoClient(
//                dutchTreatDatabaseSettings.Value.ConnectionString);

//            var mongoDatabase = mongoClient.GetDatabase(
//                dutchTreatDatabaseSettings.Value.DatabaseName);

//            _productsCollection = mongoDatabase.GetCollection<Product>(
//                dutchTreatDatabaseSettings.Value.ProductsCollectionName);
//        }

//        public async Task<List<Product>> GetAsync() =>
//            await _productsCollection.Find(_ => true).ToListAsync();

//        public async Task<Product> GetAsync(string id) =>
//            await _productsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

//        public async Task CreateAsync(Product newProduct) =>
//            await _productsCollection.InsertOneAsync(newProduct);

//        public async Task UpdateAsync(string id, Product updatedProduct) =>
//            await _productsCollection.ReplaceOneAsync(x => x.Id == id, updatedProduct);

//        public async Task RemoveAsync(string id) =>
//            await _productsCollection.DeleteOneAsync(x => x.Id == id);
//    }
//}