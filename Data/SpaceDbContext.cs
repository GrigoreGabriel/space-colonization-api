using Microsoft.EntityFrameworkCore;
using space_colonization_api.Data.Captains;
using space_colonization_api.Data.Expeditions;
using space_colonization_api.Data.Planets;
using space_colonization_api.Data.Robots;
using space_colonization_api.Data.RobotTeams;
using space_colonization_api.Data.Shuttles;
using space_colonization_api.Data.Statuses;
using space_colonization_api.Data.Teams;
using System.Reflection;

namespace space_colonization_api.Data
{
    public class SpaceDbContext : DbContext
    {
        public SpaceDbContext(DbContextOptions<SpaceDbContext> options) : base(options) { }

        public DbSet<Captain> Captains { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Robot> Robots { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<RobotTeam> RobotTeams { get; set; }
        public DbSet<Expedition> Expeditions { get; set; }
        public DbSet<Shuttle> Shuttles { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
