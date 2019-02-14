
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myLibrary.Model;
namespace myLibrary
{
    public class postgresContext : DbContext
    {

        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<User> User { get; set; }

        public postgresContext(DbContextOptions<postgresContext> options)
            : base(options)
        {
        }

        public postgresContext()
        {
        }

        public void Find(User user)
        {
            throw new NotImplementedException();
        }
    }
}