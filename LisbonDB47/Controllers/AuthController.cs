using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LisbonDB47.Helpers;
using LisbonDB47.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LisbonDB47.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly LisbonDbContext _context;

        public AuthController(LisbonDbContext context)
        {
            _context = context;
        }
        // POST api/values
        [HttpPost]
        public ActionResult Login([FromBody] User user)
        {
            Console.WriteLine("--------------------- " + user.Mail);
            Console.WriteLine("--------------------- " + user.Password);

            var foundedUser = _context.Users.Where(u => u.Mail == user.Mail).First();
            bool ok = false;

            if(user != null)
            {
                ok = SecurePasswordHasher.Verify(user.Password, foundedUser.Password);
                foundedUser.Password = null;
                // if user is not active also set to false
            }

            if(ok)
            {
                return Ok(foundedUser);
            }
            else
            {
                return NotFound();
            }
        }

        // PUT api/values/5
        [HttpPost("register")]
        public void Put(int id, [FromBody]string value)
        {
        }
    }
}
