using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LMS.Models
{
    public class DbContextApp : IdentityDbContext<ApplicationUser>
    {
        public DbContextApp(DbContextOptions<DbContextApp> option) : base(option)
        {

        }
       
        public DbSet<Register> Registers { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Book> Books { get; set; }
         public DbSet<Branch> Branches { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<BoookIssue> BookIssues { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Penalty> Penalties { get; set; }

    }
}
