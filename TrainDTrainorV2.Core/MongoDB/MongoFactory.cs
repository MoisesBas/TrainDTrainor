using System;
using MongoDB.Driver;

namespace TrainDTrainorV2.Core.MongoDB
{
    public static class MongoFactory
    {
        
        public static IMongoDatabase GetDatabaseFromConnectionString(string connectionString)
        {
            var mongoUrl = new MongoUrl(connectionString);
            return GetDatabaseFromMongoUrl(mongoUrl);
        }

      
        public static IMongoDatabase GetDatabaseFromMongoUrl(MongoUrl mongoUrl)
        {
            var client = new MongoClient(mongoUrl);
            var mongoDatabase = client.GetDatabase(mongoUrl.DatabaseName);
            return mongoDatabase;
        }        

    }
}
