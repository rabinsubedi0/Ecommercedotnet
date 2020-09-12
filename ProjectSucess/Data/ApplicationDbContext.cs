using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectSucess.Models;

namespace ProjectSucess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TotalProduct> TotalProducts { get; set; }

        public DbSet<cart> Cart { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Admin_Login> Admin_Login { get; set; }

        public DbSet<Manager> manager { get; set;  }

       
    }
}
