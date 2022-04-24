using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace MongoData.v02
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var client = new MongoClient(
    "mongodb+srv://TheNatan28:vgMeikS7-ME7uuJ@clusterl02.jg4jv.mongodb.net/myFirstDatabase?retryWrites=true&w=majority"
);
            var database = client.GetDatabase("mDbContext");

            var dbList = client.ListDatabases().ToList();

            Console.WriteLine("The list of databases are:");

            foreach (var item in dbList)
            {
                Console.WriteLine(item);
            }

            IMongoDatabase db = client.GetDatabase("mDbContext");

            var command = new BsonDocument { { "dbstats", 1 } };
            var result = db.RunCommand<BsonDocument>(command);
            Console.WriteLine(result.ToJson());

            var users = db.GetCollection<BsonDocument>("userTable");

            var filter = Builders<BsonDocument>.Filter.Eq("Full_Name", "Angelita Itzkovitch");

            var doc = users.Find(filter).FirstOrDefault();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(doc.ToJson());
        }
    }
}
