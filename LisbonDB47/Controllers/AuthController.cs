using System;
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
        // POST api/auth
        [HttpPost]
        public ActionResult Login([FromBody] User user)
        {
            Console.WriteLine("--------------------- " + user.Mail);
            Console.WriteLine("--------------------- " + user.Password);

            User foundedUser = null;
            try
            {
                foundedUser = _context.Users.Where(u => u.Mail == user.Mail).First();
            }
            catch (Exception)
            {

            }
            bool ok = false;

            if (foundedUser != null)
            {
                ok = user.Password == foundedUser.Password;
                if (ok == false)
                {
                    ok = SecurePasswordHasher.Verify(user.Password, foundedUser.Password);
                }
                foundedUser.Password = null;
                // if user is not active also set to false
            }

            if (ok)
            {
                if(foundedUser.Active == false)
                {
                    return Unauthorized();
                }
                return Ok(foundedUser);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/auth/check
        [HttpPost("check")]
        public async Task<IActionResult> CheckUser([FromBody] User user)
        {
            if (user == null || user.UserID == 0 || user.Mail == null || user.Mail == "")
            {
                return NotFound();
            }

            User foundedUser = await _context.Users.FindAsync(user.UserID);
            if (foundedUser != null && foundedUser.Mail == user.Mail)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost("change/{newPassword}")]
        public async Task<IActionResult> Change([FromBody] User user, [FromRoute] String newPassword)
        {
            if (user == null || user.UserID == 0 || user.Password == null || user.Password == "" || newPassword == null || newPassword == "")
            {
                return NotFound();
            }

            User foundedUser = await _context.Users.FindAsync(user.UserID);
            var ok = SecurePasswordHasher.Verify(user.Password, foundedUser.Password);
            if (foundedUser != null && ok)
            {
                foundedUser.Password = SecurePasswordHasher.Hash(newPassword);
                _context.Users.Update(foundedUser);
                _context.SaveChanges();
                // set new password

                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
