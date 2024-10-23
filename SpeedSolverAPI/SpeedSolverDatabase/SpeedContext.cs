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

        public DbSet<InProjectMessageEntity> InProjectMessages { get; set; }
        public DbSet<InvitationEntity> Invitations { get; set; }
        public DbSet<ObjectiveEntity> Objectives { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<ProjectModeratorEntity> ProjectModerators { get; set; }
        public DbSet<TeamEntity> Teams { get; set; }
        public DbSet<TeamObjectiveEntity> TeamObjectives { get; set; }
        public DbSet<UnderObjectiveEntity> UnderObjectives { get; set; }
        public DbSet<UserEntity> Users { get; set; }


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
            modelBuilder.ApplyConfiguration(new InProjectMessagesEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UnderEntityObjectiveConfiguration());
            modelBuilder.ApplyConfiguration(new TeamEntityObjectiveConfiguration());
            modelBuilder.ApplyConfiguration(new InvitationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectEntityModeratorConfiguration());
            modelBuilder.ApplyConfiguration(new TeamEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ObjectiveEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
