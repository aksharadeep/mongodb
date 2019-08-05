using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
  public  interface IKeepService
    {
        Note GetNoteById(int id);
        List<Note> GetNotes();
        void AddNote(Note note);
        bool UpdateNote(int id ,Note note);
        bool DeleteNote(int id);
    }
}
