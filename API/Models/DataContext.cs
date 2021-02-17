using Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<Turn> Turns { get; set; }
        public DbSet<Queue> Queues { get; set; }

    }
}