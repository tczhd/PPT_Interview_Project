
using Microsoft.EntityFrameworkCore;
using PPTWebApiService.Entities;

namespace PPTWebApiService.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Image> Images { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> opt)
        : base(opt)
        { }
    }
}