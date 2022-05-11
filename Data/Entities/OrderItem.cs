using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DutchTreat.Data
{
    public class OrderItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Order Order { get; set; }
    }
}
