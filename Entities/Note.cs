using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Entities
{
    public class Note
    {

        public Note()
        {
            labels = new List<Label>();
        }

        [BsonId]
        public int NoteId { get; set; }
        [BsonElement("title")]
        public string Title { get; set; }
        [BsonElement("text")]
        public string Text { get; set; }
        [BsonElement("labelgroups")]
        public ICollection<Label> labels { get; set; }
    }
}
