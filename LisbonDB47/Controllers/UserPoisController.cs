﻿using System;
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
    public class UserPoisController : ControllerBase
    {
        private readonly LisbonDbContext _context;

        public UserPoisController(LisbonDbContext context)
        {
            _context = context;
        }

        // GET: api/UserPois
        [HttpGet]
        public IEnumerable<UserPoi> GetUserPois()
        {
            return _context.UserPois.Include(up => up.Images).ToList();
        }

        // GET: api/UserPois/public
        [HttpGet("public")]
        public async Task<IActionResult> GetPublicUserPois()
        {
            var publicUsersPois = await _context.UserPois.Where(up => up.Private == false)
                                                   .Include(up => up.Poi)
                                                   .Include(up => up.Images)
                                                   .Include(up => up.User).ToListAsync();

            foreach(UserPoi up in publicUsersPois)
            {
                up.User.UserPois = null;
            }
            if (publicUsersPois == null)
            {
                return NotFound();
            }
            return Ok(publicUsersPois);
        }

         //GET: api/UserPois/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserPoi([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userPoi = await _context.UserPois
                                    .Where(up => up.UserPoiID == id)
                                    .Include(up => up.Poi)
                                    .Include(up => up.Images)
                                    .Include(up => up.Comments).ThenInclude(c => c.User)
                                    .Include(up => up.Likes).ThenInclude(l => l.User)
                                    .FirstAsync();

            if (userPoi == null)
            {
                return NotFound();
            }

            return Ok(userPoi);
        }

        // GET: api/UserPois/forUser/5
        [HttpGet("forUser/{userId}")]
        public async Task<IActionResult> GetUserPoisByUserId([FromRoute] int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userPois = await _context.UserPois
                                    .Where(up => up.UserID == userId)
                                    .Include(up => up.Images)
                                    .ToListAsync();

            if (userPois == null)
            {
                return NotFound();
            }

            return Ok(userPois);
        }

        // PUT: api/UserPois/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserPoi([FromRoute] int id, [FromBody] UserPoi userPoi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userPoi.UserPoiID)
            {
                return BadRequest();
            }

            _context.Entry(userPoi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserPoiExists(id))
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

        // POST: api/UserPois
        [HttpPost]
        public async Task<IActionResult> PostUserPoi([FromBody] UserPoi userPoi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserPois.Add(userPoi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserPoi", new { id = userPoi.UserPoiID }, userPoi);
        }

        // DELETE: api/UserPois/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserPoi([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userPoi = await _context.UserPois.FindAsync(id);
            if (userPoi == null)
            {
                return NotFound();
            }

            _context.UserPois.Remove(userPoi);
            await _context.SaveChangesAsync();

            return Ok(userPoi);
        }

        private bool UserPoiExists(int id)
        {
            return _context.UserPois.Any(e => e.UserPoiID == id);
        }
    }
}