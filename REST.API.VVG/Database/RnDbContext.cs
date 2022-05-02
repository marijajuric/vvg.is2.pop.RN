using Microsoft.EntityFrameworkCore;
using Model.VVG.model;
namespace REST.API.VVG.Database
{
    public class RnDbContext : DbContext
    {
        public RnDbContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<Equipment>? Equipment { get; set; }
        public DbSet<Material>? Material { get; set; }
        public DbSet<Service>? Service { get; set; }
        public DbSet<WorkOrder>? WorkOrder { get; set; }
        public DbSet<WorkOrderService>? WorkOrderService { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=warehouse;Username=postgres;Password=postgres");
    }
}
