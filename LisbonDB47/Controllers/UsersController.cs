using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LisbonDB47.Models;
using LisbonDB47.Helpers;

namespace LisbonDB47.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly LisbonDbContext _context;

        public UsersController(LisbonDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            //if (_context.Users.Count() < 3)
            //{
            //    var u1 = _context.Users.Where(x => x.Name == "userFromController").FirstOrDefault();
            //    if(u1 is null)
            //    {
            //        int x = _context.Users.Count();
            //        User u = new User();
            //        u.UserID = _context.Users.Count() + 1;
            //        u.Name = "userFromController";
            //        u.Mail = "testFromControllermail@gmail.com";
            //        u.Password = "testFromControllerpass10p+";
            //        _context.Users.Add(u);
            //        _context.SaveChanges();
            //    }
               
            //}
            return _context.Users;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // GET: api/Users/getUsedMails
        [HttpGet("getUsedMails")]
        public async Task<IActionResult> GetUsedMails()
        {
            var mails = await _context.Users.Select(u => u.Mail).ToListAsync();

            if (mails == null)
            {
                return NotFound();
            }
            return Ok(mails);
        }

        // GET: api/Users/checkMail/aa@aa.pl
        [HttpGet("checkMail/{mail}")]
        public async Task<IActionResult> CheckEmail([FromRoute] string mail)
        {
            var users = await _context.Users.Where(u => u.Mail == mail).ToListAsync();

            if (users.Count == 0 || users == null)
            {
                return Ok();
            }
            else
            {
                return Conflict();
            }
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromRoute] int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserID)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            user.Password = SecurePasswordHasher.Hash(user.Password);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserID }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserID == id);
        }
    }
}