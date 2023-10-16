using UserManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace  UserManagement.Data.Models

{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }
        public DbSet<UserDetailsModel> UserDetails { get; set; }
    }
}
