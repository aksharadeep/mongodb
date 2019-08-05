using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Exception;
using DataAccess;
using Entities;

namespace BusinessLayer
{
    public class KeepService : IKeepService
    {
        private readonly INoteHandler noteHandler;
        public KeepService(INoteHandler handler)
        {
            noteHandler = handler;
        }

        //method to add a note and throw respective exception
        public void AddNote(Note note)
        {
            var keepNote = noteHandler.GetNoteById(note.NoteId);
            if (keepNote == null)
            {
                noteHandler.AddNote(note);
            }
            else
            {
                throw new NoteAlreadyExistsException($"Note with id {note.NoteId} already exists");
            }

        }
        // method to get note by id and throw respective exception
        public Note GetNoteById(int id)
        {
            var keepNote = noteHandler.GetNoteById(id);
            if (keepNote == null)
            {
                throw new NoteNotFoundException($"Note with id {id} not found");
            }
            else
            {
                return keepNote;
            }
        }
        //method to get all notes
        public List<Note> GetNotes()
        {
            return noteHandler.GetNotes();
        }
        //method to update the note
        public bool UpdateNote(int id,Note note)
        {
            var keepNote = noteHandler.GetNoteById(note.NoteId);
            if (keepNote == null)
            {
                throw new NoteNotFoundException($"Note with id {note.NoteId} not found");
            }
            else
            {
                keepNote.Text = note.Text;
                keepNote.Title = note.Title;
                return noteHandler.UpdateNote(id,keepNote);
            }
        }
        //method to delete a note by id
        public bool DeleteNote(int id)
        {
            var keepNote = noteHandler.GetNoteById(id);
            if (keepNote == null)
            {
                throw new NoteNotFoundException($"Note with id {id} not found");
            }
            else
            {
                return noteHandler.DeleteNote(id);
            }
        }
    }
}
