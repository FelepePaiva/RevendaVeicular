using Microsoft.EntityFrameworkCore;
using RevendaVeicular.Model;

namespace RevendaVeicular.Infra
{
    public class ConnectionContext : DbContext
    {
        public DbSet<VehicleModel> vehicleModels { get; set; }
        public DbSet<EmployerModel> employerModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
               "Server = localhost;" +
               "Port = 5432;Database = vehicle;" +
               "User Id = postgres;" +
               "Password = 1234567;"
               );
            optionsBuilder.UseNpgsql(
               "Server = localhost;" +
               "Port = 5432;Database = employer;" +
               "User Id = postgres;" +
               "Password = 1234567;"
         );

        }
        

    }
}
