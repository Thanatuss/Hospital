using Domain.SQL.Token;
using Domain.SQL.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class ProgramDbContext : DbContext
    {
        public ProgramDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<BlackListToken> BlackToken { get; set; }
    }
}
