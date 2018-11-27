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
    public class PathPoisController : ControllerBase
    {
        private readonly LisbonDbContext _context;

        public PathPoisController(LisbonDbContext context)
        {
            _context = context;
        }

        // GET: api/PathPois
        [HttpGet]
        public IEnumerable<PathPoi> GetPathPois()
        {
            return _context.PathPois;
        }

        // GET: api/PathPois/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPathPoi([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pathPoi = await _context.PathPois.FindAsync(id);

            if (pathPoi == null)
            {
                return NotFound();
            }

            return Ok(pathPoi);
        }

        // PUT: api/PathPois/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPathPoi([FromRoute] int id, [FromBody] PathPoi pathPoi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pathPoi.PathPoiID)
            {
                return BadRequest();
            }

            _context.Entry(pathPoi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PathPoiExists(id))
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

        // POST: api/PathPois
        [HttpPost]
        public async Task<IActionResult> PostPathPoi([FromBody] PathPoi pathPoi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PathPois.Add(pathPoi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPathPoi", new { id = pathPoi.PathPoiID }, pathPoi);
        }

        // DELETE: api/PathPois/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePathPoi([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pathPoi = await _context.PathPois.FindAsync(id);
            if (pathPoi == null)
            {
                return NotFound();
            }

            _context.PathPois.Remove(pathPoi);
            await _context.SaveChangesAsync();

            return Ok(pathPoi);
        }

        private bool PathPoiExists(int id)
        {
            return _context.PathPois.Any(e => e.PathPoiID == id);
        }
    }
}