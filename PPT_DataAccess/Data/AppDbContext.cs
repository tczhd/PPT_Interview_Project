using Microsoft.EntityFrameworkCore;
using PPTWebApiService.DataAccess.Entities;

namespace PPTWebApiService.DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> opt)
        : base(opt)
        { }

        public AppDbContext()
        { }

        public virtual DbSet<Image> Images { get; set; }
    }
}