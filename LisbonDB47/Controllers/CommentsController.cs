using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LisbonDB47.Models;

namespace LisbonDB47.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly LisbonDbContext _context;

        public CommentsController(LisbonDbContext context)
        {
            _context = context;
        }

        // GET: api/Comments
        [HttpGet]
        public IEnumerable<Comment> GetComments()
        {
            return _context.Comments;
        }

        // GET: api/Comments/forUser/5
        [HttpGet("forUser/{userId}")]
        public async Task<IActionResult> GetCommentsForUser([FromRoute] int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //TODO: fixed after migration - not tested 1
            var poisForUser = await _context.Pois.Where(p => p.UserID == userId).ToListAsync();

            List<Comment> commentsForUser = new List<Comment>();

            foreach(Poi p in poisForUser)
            {
                var poiComments = _context.Comments.Where(c => c.PoiID == p.PoiID)
                                                    .Include(l => l.User)
                                                    .Include(l => l.Poi)
                                                    .ThenInclude(l => l.Images)
                                                    .OrderByDescending(c=>c.DateCreated);
                                                    
                foreach (Comment c in poiComments)
                {
                    commentsForUser.Add(c);
                }
            }

            if (commentsForUser == null)
            {
                return NotFound();
            }

            return Ok(commentsForUser);
        }

        // GET: api/Comments/forPoi/5
        [HttpGet("forPoi/{poiId}")]
        public async Task<IActionResult> GetCommentsForPoi([FromRoute] int poiId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comments = await _context.Comments.Where(c => c.PoiID == poiId).Include(c => c.User).OrderByDescending(c => c.DateCreated).ToListAsync();

            if (comments == null)
            {
                return NotFound();
            }

            return Ok(comments);
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comment = await _context.Comments.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        // PUT: api/Comments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment([FromRoute] int id, [FromBody] Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comment.CommentID)
            {
                return BadRequest();
            }

            _context.Entry(comment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
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

        // POST: api/Comments
        [HttpPost]
        public async Task<IActionResult> PostComment([FromBody] Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            comment = await _context.Comments.Include(c => c.User).Where(c => c.CommentID == comment.CommentID).FirstAsync();

            return CreatedAtAction("GetComment", new { id = comment.CommentID }, comment);
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return Ok(comment);
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.CommentID == id);
        }
    }
}