using System;
using System.Linq;
using LisbonDB47.Models;

namespace LisbonDB47
{
    internal class DbInitializer
    {
        internal static void SeedData(LisbonDbContext _context)
        {
            _context.Database.EnsureCreated();//if db is not exist ,it will create database .but ,do nothing

            if (_context.Users.Count() == 0)
            {
                int x = _context.Users.Count();
                User u = new User();
                u.UserID = _context.Users.Count() + 1;
                u.Name = "userTest";
                u.Mail = "testmail@gmail.com";
                u.Password = "testpass10p+";
                _context.Users.Add(u);
                _context.SaveChanges();
            }
        }
    }
}