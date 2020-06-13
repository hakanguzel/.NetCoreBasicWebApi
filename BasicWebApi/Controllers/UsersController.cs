using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicWebApi.Models;
using BasicWebApi.Models.Dto;
using BasicWebApi.Models.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebApi.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly StickyNotesContext _StickyNotes;
        public UsersController(StickyNotesContext StickyNotes)
        {
            _StickyNotes = StickyNotes;
        }
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _StickyNotes.Users.ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(Guid id)
        {
            var user = _StickyNotes.Users.FirstOrDefault(p => p.Id == id);
            if (user is null) return NotFound();

            return user;
        }
        [HttpPost]
        public ActionResult Post(UserDto userDto)
        {
            var user = new User { FirstName = userDto.FirstName, LastName = userDto.LastName };
            _StickyNotes.Users.Add(user);
            _StickyNotes.SaveChanges();
            return CreatedAtAction("Get", new { id = user.Id }, user);
        }


        [HttpPut("{id}")]
        public ActionResult Put(Guid id, UserDto userDto)
        {
            var user = _StickyNotes.Users.FirstOrDefault(p => p.Id == id);
            if (user is null)
            {
                user = new User { FirstName = userDto.FirstName, LastName = userDto.LastName, Id = id };
                _StickyNotes.Users.Add(user);
                _StickyNotes.SaveChanges();
                return CreatedAtAction("Get", new { id = id }, user);
            }
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            _StickyNotes.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var user = _StickyNotes.Users.FirstOrDefault(p => p.Id == id);
            if (user is null) return NotFound();

            _StickyNotes.Remove(user);
            _StickyNotes.SaveChanges();
            return NoContent();
        }
    }
}
