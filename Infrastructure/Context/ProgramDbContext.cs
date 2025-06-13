using Domain.SQL.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class ProgramDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
