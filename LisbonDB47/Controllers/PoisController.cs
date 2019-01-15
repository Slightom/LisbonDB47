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
    public class PoisController : ControllerBase
    {
        private readonly LisbonDbContext _context;

        public PoisController(LisbonDbContext context)
        {
            _context = context;
        }

        // GET: api/Pois
        [HttpGet]
        public IEnumerable<Poi> GetPois()
        {
            return _context.Pois.Include(p => p.Images).ToList();
        }

        // GET: api/Pois/public
        [HttpGet("public")]
        public IEnumerable<Poi> GetPublicPois()
        {
            return _context.Pois.Include(p => p.Images).Where(p => p.Private == false).ToList();
        }

        // GET: api/Pois/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPoi([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var poi = await _context.Pois.FindAsync(id);

            if (poi == null)
            {
                return NotFound();
            }

            return Ok(poi);
        }

        // PUT: api/Pois/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoi([FromRoute] int id, [FromBody] Poi poi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != poi.PoiID)
            {
                return BadRequest();
            }

            _context.Entry(poi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoiExists(id))
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

        // POST: api/Pois
        [HttpPost]
        public async Task<IActionResult> PostPoi([FromBody] Poi poi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Pois.Add(poi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoi", new { id = poi.PoiID }, poi);
        }

        // DELETE: api/Pois/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoi([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var poi = await _context.Pois.FindAsync(id);
            if (poi == null)
            {
                return NotFound();
            }

            _context.Pois.Remove(poi);
            await _context.SaveChangesAsync();

            return Ok(poi);
        }

        private bool PoiExists(int id)
        {
            return _context.Pois.Any(e => e.PoiID == id);
        }
    }
}