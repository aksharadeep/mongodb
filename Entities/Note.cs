using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Entities
{
    public class Note
    {
        [BsonId]
        public int NoteId { get; set; }
        [BsonElement("title")]
        public string Title { get; set; }
        [BsonElement("text")]
        public string Text { get; set; }
        [BsonIgnore]
        public ICollection<Label> labels { get; set; }
    }
}
