using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    public class List
    {
        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
        public List<ListItem> ListItems { get; set; }
    }
}
