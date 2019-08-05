using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Label
    {
       [BsonId]
        public int LabelId { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("noteid")]
        public int NoteId { get; set; }
    }
}