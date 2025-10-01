using HoopDreams.Models;
using Microsoft.EntityFrameworkCore;

namespace HoopDreams.NewFolder
{
    public class ClientsContext : DbContext
    {
        public DbSet<FormEntity> FormEntities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("MyDb");
        }
    }
}
