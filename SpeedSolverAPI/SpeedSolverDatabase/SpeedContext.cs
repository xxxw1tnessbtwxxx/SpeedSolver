using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using SpeedSolverDatabase.Models;
using SpeedSolverDatabase.Models.Configurations;

namespace SpeedSolverDatabase
{
    public sealed class SpeedContext: DbContext
    {

        public bool IsConnected { get; set; } = false;

        public DbSet<InProjectMessage> InProjectMessages { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<Objective> Objectives { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectModerator> ProjectModerators { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamObjective> TeamObjectives { get; set; }
        public DbSet<UnderObjective> UnderObjectives { get; set; }
        public DbSet<User> Users { get; set; }


        public SpeedContext(DbContextOptions options)
        {
            try
            {
                this.IsConnected = Database.CanConnect();
            }
            catch
            {
                this.IsConnected = false;
            }
        }

        public SpeedContext()
        {
            try
            {
                this.IsConnected = Database.CanConnect();
            }
            catch
            {
                this.IsConnected = false;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=speedsolver.database;Port=5432;Username=postgres;Password=555;Database=speedsolver;TrustServerCertificate=true")
                .EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InProjectMessagesConfiguration());
            modelBuilder.ApplyConfiguration(new UnderObjectiveConfiguration());
            modelBuilder.ApplyConfiguration(new TeamObjectiveConfiguration());
            modelBuilder.ApplyConfiguration(new InvitationConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectModeratorConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new ObjectiveConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
