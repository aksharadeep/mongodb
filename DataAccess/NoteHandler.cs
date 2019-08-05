using System.Collections.Generic;
using System.Linq;
using Entities;
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
    }
}
