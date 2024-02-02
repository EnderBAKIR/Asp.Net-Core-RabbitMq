using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RabbitMQExelCreat_WEB.APP.Models
{
    public class AppDbContext : IdentityDbContext<AppUser , AppRole, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<UserFile> UserFiles { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
    }
}
