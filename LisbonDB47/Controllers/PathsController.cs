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
    public class PathsController : ControllerBase
    {
        private readonly LisbonDbContext _context;

        public PathsController(LisbonDbContext context)
        {
            _context = context;
        }

        // GET: api/Paths
        [HttpGet]
        public IEnumerable<Path> GetPaths()
        {
            return _context.Paths;
        }

        // GET: api/Paths/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPath([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var path = await _context.Paths.FindAsync(id);

            if (path == null)
            {
                return NotFound();
            }

            return Ok(path);
        }

        // PUT: api/Paths/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPath([FromRoute] int id, [FromBody] Path path)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != path.PathID)
            {
                return BadRequest();
            }

            _context.Entry(path).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PathExists(id))
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

        // POST: api/Paths
        [HttpPost]
        public async Task<IActionResult> PostPath([FromBody] Path path)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Paths.Add(path);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPath", new { id = path.PathID }, path);
        }

        // DELETE: api/Paths/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePath([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var path = await _context.Paths.FindAsync(id);
            if (path == null)
            {
                return NotFound();
            }

            _context.Paths.Remove(path);
            await _context.SaveChangesAsync();

            return Ok(path);
        }

        private bool PathExists(int id)
        {
            return _context.Paths.Any(e => e.PathID == id);
        }
    }
}