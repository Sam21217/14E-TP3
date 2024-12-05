using MongoDB.Driver;
using System.Configuration;

namespace Automate.Utils.DataServices
{
    public class MongoDBService
    {
        private readonly IMongoDatabase _database;
        public MongoDBService()
        {
            var client = new MongoClient(ConfigurationManager.AppSettings["MongoUrl"]!);
            _database = client.GetDatabase(ConfigurationManager.AppSettings["DBName"]!);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }

}
