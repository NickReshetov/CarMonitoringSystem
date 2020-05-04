using DataStorage.DataAccess.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataStorage.DataAccess.EntityFramework
{
    public class DataStorageDbContext : DbContext
    {
        public DataStorageDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Car> Cars { get; set; }
    }
}