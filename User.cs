using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbCrudDemo.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("hasBiometricData")]
        public bool HasBiometricData { get; set; }

        [BsonElement("fingerprintHash")]
        public string FingerprintHash { get; set; } // Pode simular um hash da digital
    }
}
