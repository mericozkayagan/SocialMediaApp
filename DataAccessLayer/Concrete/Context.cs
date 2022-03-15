using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
   public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }        

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }        
        public DbSet<Message> Messages { get; set; }        
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
