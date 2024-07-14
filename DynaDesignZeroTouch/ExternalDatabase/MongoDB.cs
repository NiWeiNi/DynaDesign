using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace DynaDesignZeroTouch.ExternalDatabase
{
    public class MongoDB
    {
        private MongoDB() { }

        public static async Task ConnectClient(string connectionString, string databaseName, string collectionName)
        {
            await Task.Run(() =>
            {
                var client = new MongoClient(connectionString);
                // Database reference with creation if it does not already exist
                var database = client.GetDatabase(databaseName);
                var collection = database.GetCollection<BsonDocument>(collectionName);
            });
        }

        public static async Task InsertDocument(BsonDocument bsonDocument)
        {
            await InsertDocument(bsonDocument);
        }
    }
}
