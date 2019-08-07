using System.Collections.Generic;
using System.Linq;
using Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataAccess
{
    public class NoteHandler : INoteHandler
    {
        private readonly NoteDbContext context;
        public NoteHandler(NoteDbContext noteDbContext)
        {
            context = noteDbContext;
        }

        public void AddNote(Note note)
        { 
            context.notes.InsertOne(note);
        }

        public Note GetNoteById(int id)
        {
            return context.notes.Find(n => n.NoteId == id).FirstOrDefault();
        }

        public List<Note> GetNotes()
        {
            return context.notes.Find(_ => true).ToList();
        }

        public bool UpdateNote(int id,Note note)
        {
            var filter = Builders<Note>.Filter.Where(n => n.NoteId == id);
            var updatedResult = context.notes.ReplaceOne(filter, note);
            return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
        }
        public bool DeleteNote(int id)
        {
            var deleteResult = context.notes.DeleteOne(n => n.NoteId == id);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public void AddLabel(int noteId,Label label)
        {
            int LabelId = GetNewId(noteId);
            label.LabelId = LabelId;
            var filter = Builders<Note>.Filter.Eq(n => n.NoteId, noteId);
            var update = Builders<Note>.Update.Push(e => e.labels, label);
            context.notes.FindOneAndUpdate(filter, update);
        }
        public int GetNewId(int noteId)
        {
            return context.notes.AsQueryable().Where(n => n.NoteId == noteId).FirstOrDefault().labels.Max(l => l.LabelId)+1;
        }
         public void UpdateLabel(int noteId,Label label)
         {
           Note noteToUpdate =  context.notes.Find(n => n.NoteId == noteId).First();
           Label _label=  noteToUpdate.labels.First(l => l.LabelId == label.LabelId);
            _label.Description = label.Description;
            context.notes.ReplaceOne(n => n.NoteId == noteToUpdate.NoteId, noteToUpdate);
         }

        public ICollection<Label> GetLabels(int noteId)
        {
            Note noteToGet = context.notes.Find(n => n.NoteId == noteId).First();
            return noteToGet.labels;

        }

        public void DeleteLabelByNoteIdAndLabelId(int noteId, int labelId)
        {
            Note noteToGet = context.notes.Find(n => n.NoteId == noteId).First();
            Label label = noteToGet.labels.First(l => l.LabelId == labelId);

            var filter = Builders<Note>.Filter.Eq(n => n.NoteId, noteId);
            var update = Builders<Note>.Update.Pull(e => e.labels, label);
            context.notes.FindOneAndUpdate(filter, update);
        }

        public Label GetLabelById(int noteId,int labelId)
        {
            Note noteToGet = context.notes.Find(n => n.NoteId == noteId).First();
            Label label = noteToGet.labels.First(l => l.LabelId == labelId);
            return label;
        }
    }
}
