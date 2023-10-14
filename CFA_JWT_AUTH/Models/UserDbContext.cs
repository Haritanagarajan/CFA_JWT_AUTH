using Microsoft.EntityFrameworkCore;

namespace CFA_JWT_AUTH.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }
        public DbSet<UserDetailsModel> UserDetails { get; set; }
    }
}
