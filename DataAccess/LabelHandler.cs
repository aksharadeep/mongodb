using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using MongoDB.Driver;

namespace DataAccess
{
    public class LabelHandler : ILabelHandler
    {
        private readonly NoteDbContext context;
        public LabelHandler(NoteDbContext noteDbContext)
        {
            context = noteDbContext;
        }

        public void AddLabel(Label label)
        {
            context.labels.InsertOne(label);
        }

        public Label GetLabelById(int id)
        {
            return context.labels.Find(l => l.LabelId == id).FirstOrDefault();
        }

        public List<Label> GetLabels()
        {
            return context.labels.Find(_ => true).ToList();
        }

        public bool UpdateLabel(int id, Label label)
        {
            var filter = Builders<Label>.Filter.Where(l => l.LabelId == id);
            var updatedResult = context.labels.ReplaceOne(filter, label);
            return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
        }
        public bool DeleteLabel(int id)
        {
            var deleteResult = context.labels.DeleteOne(l=> l.LabelId == id);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
    }
}
