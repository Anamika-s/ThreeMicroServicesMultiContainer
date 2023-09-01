
using MongoDB.Bson.Serialization.Attributes;

namespace OrderApi.Models
{
    [Serializable,BsonIgnoreExtraElements]
    public class OrderDetail
    {
        [BsonElement("product_id"), BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        public int ProductId { get; set; }

        [BsonElement("qty"), BsonRepresentation(MongoDB.Bson.BsonType.Decimal128)]
        public decimal Qty { get; set; }

        [BsonElement("unit_price"), BsonRepresentation(MongoDB.Bson.BsonType.Decimal128)]
        public decimal  UnitPrice { get; set; }


    }
}
