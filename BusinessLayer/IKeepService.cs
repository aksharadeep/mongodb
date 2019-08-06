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
        void AddLabel(int noteId, Label label);
        void UpdateLabel(int noteId, Label label);
        ICollection<Label> GetLabels(int noteId);
        void DeleteLabelByNoteIdAndLabelId(int noteId, int labelId);
    }
}
