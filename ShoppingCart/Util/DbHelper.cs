using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using Models;
using System.Collections.Generic;

namespace Util
{
    public static class DbHelper
    {
        private const string CLIENT_URI = "mongodb://localhost:27017";
        private const string DB_NAME = "shopping_cart";
        private const string COLL_NAME = "list";

        private static MongoClient client = new MongoClient(CLIENT_URI);
        private static IMongoDatabase database = client.GetDatabase(DB_NAME); //create new database
        private static IMongoCollection<List> collection = database.GetCollection<List>(COLL_NAME);

        public static void UpdateListItems(string listId, List list)
        {
            var update = Builders<List>.Update.Set("ListItems", list.ListItems);
            collection.UpdateOneAsync(o=> o.Id == listId, update);
        }

        public static List CreateList(List list)
        {
            collection.InsertOne(list);
            return list;
        }

        public static List GetListInfo(string listId)
        {
            return collection.Find<List>(o=> o.Id == listId).FirstOrDefault();
        }
    }
}
