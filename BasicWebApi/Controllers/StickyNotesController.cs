using System;
using System.Collections.Generic;
using System.Linq;
using BasicWebApi.Models;
using BasicWebApi.Models.Dto;
using BasicWebApi.Models.Entites;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebApi.Controllers
{
    [Route("api/v1/users/{userId}/stickyNotes")]
    [ApiController]
    public class StickyNotesController : ControllerBase
    {
        private readonly StickyNotesContext _stickyNotes;
        public StickyNotesController(StickyNotesContext stickyNotes)
        {
            _stickyNotes = stickyNotes;
        }


        public ActionResult<IEnumerable<StickyNote>> Get(Guid userId)
        {
            return _stickyNotes.StickyNotes.Where(p => p.UserId == userId).ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<StickyNote> Get(Guid userId, Guid id)
        {
            var author = _stickyNotes.StickyNotes.FirstOrDefault(p => p.UserId == userId && p.Id == id);
            if (author is null) return NotFound();

            return author;
        }

        [HttpPost]
        public ActionResult Post(Guid userId, StickyNoteDto stickyNoteDto)
        {

            var stickyNote = new StickyNote { Title = stickyNoteDto.Title, Note = stickyNoteDto.Note, UserId = userId, Id = Guid.NewGuid() };
            _stickyNotes.StickyNotes.Add(stickyNote);
            _stickyNotes.SaveChanges();
            return CreatedAtAction("Get", new { id = stickyNote.Id, userId }, stickyNote);
        }


        [HttpPut("{id}")]
        public ActionResult Put(Guid userId, Guid id, StickyNoteDto stickyNoteDto)
        {
            var author = _stickyNotes.Users.FirstOrDefault(p => p.Id == userId);
            if (author is null) return NotFound();

            var stickyNote = _stickyNotes.StickyNotes.FirstOrDefault(p => p.Id == id);
            if (stickyNote is null)
            {
                stickyNote = new StickyNote { Title = stickyNoteDto.Title, Note = stickyNoteDto.Note, UserId = userId, Id = id };
                _stickyNotes.StickyNotes.Add(stickyNote);
                _stickyNotes.SaveChanges();
                return CreatedAtAction("Get", new { id = stickyNote.Id, userId }, stickyNote);
            }
            stickyNote.Title = stickyNoteDto.Title;
            stickyNote.Note = stickyNoteDto.Note;
            _stickyNotes.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(Guid userId, Guid id)
        {
            var author = _stickyNotes.Users.FirstOrDefault(p => p.Id == userId);
            if (author is null) return NotFound();

            var book = _stickyNotes.StickyNotes.FirstOrDefault(p => p.Id == id);
            if (book is null) return NotFound();

            _stickyNotes.Remove(book);
            _stickyNotes.SaveChanges();
            return NoContent();
        }
    }
}
