using Entities;
using System.Collections.Generic;

namespace DataAccess
{
   public interface INoteHandler
    {
        Note GetNoteById(int id);
        List<Note> GetNotes();
        void AddNote(Note note);
        bool UpdateNote(int id,Note note);
        bool DeleteNote(int id);
    }
}
