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
    public class LikesController : ControllerBase
    {
        private readonly LisbonDbContext _context;

        public LikesController(LisbonDbContext context)
        {
            _context = context;
        }

        // GET: api/Likes
        [HttpGet]
        public IEnumerable<Like> GetLikes()
        {
            return _context.Likes;
        }

        // GET: api/Likes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLike([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var like = await _context.Likes.FindAsync(id);

            if (like == null)
            {
                return NotFound();
            }

            return Ok(like);
        }

        [HttpGet("forUser/{userId}")]
        public async Task<IActionResult> GetLikesForUser([FromRoute] int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //TODO: fixed after migration - not tested 2
            var poisForUser = await _context.Pois.Where(p => p.UserID == userId).ToListAsync();

            List<Like> likesForUser = new List<Like>();

            foreach (Poi p in poisForUser)
            {
                var poiLikes = _context.Likes.Where(c => c.PoiID == p.PoiID)
                                                    .Include(l => l.User)
                                                    .Include(l => l.Poi)
                                                    .ThenInclude(l => l.Images);

                foreach (Like c in poiLikes)
                {
                    likesForUser.Add(c);
                }
            }

            if (likesForUser == null)
            {
                return NotFound();
            }

            return Ok(likesForUser);
        }

        // GET: api/Likes/forUserPoi/5
        [HttpGet("forPoi/{poiId}")]
        public async Task<IActionResult> GetLikesForPoi([FromRoute] int poiId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var likes = await _context.Likes.Where(c => c.PoiID == poiId).Include(c => c.User).ToListAsync();

            if (likes == null)
            {
                return NotFound();
            }

            return Ok(likes);
        }

        // PUT: api/Likes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLike([FromRoute] int id, [FromBody] Like like)
        {
            like.DateCreated = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != like.LikeID)
            {
                return BadRequest();
            }

            _context.Entry(like).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LikeExists(id))
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

        // POST: api/Likes
        [HttpPost]
        public async Task<IActionResult> PostLike([FromBody] Like like)
        {
            like.DateCreated = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Likes.Add(like);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLike", new { id = like.LikeID }, like);
        }

        // DELETE: api/Likes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLike([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var like = await _context.Likes.FindAsync(id);
            if (like == null)
            {
                return NotFound();
            }

            _context.Likes.Remove(like);
            await _context.SaveChangesAsync();

            return Ok(like);
        }

        private bool LikeExists(int id)
        {
            return _context.Likes.Any(e => e.LikeID == id);
        }
    }
}