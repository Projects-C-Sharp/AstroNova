using Microsoft.EntityFrameworkCore;
using System;
using astronova.Entities;

namespace astronova.Data;

public class AstronovaDbContext : DbContext
{
    // DbSets para mapear las entidades
    public DbSet<Astronauts> Astronauts { get; set; }
    public DbSet<Engineers> Engineers { get; set; }
    public DbSet<ExplorationLogs> ExplorationLogs { get; set; }
    public DbSet<Missions> Missions { get; set; }
    public DbSet<Ships> Ships { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var host = Environment.GetEnvironmentVariable("DB_HOST");
        var port = Environment.GetEnvironmentVariable("DB_PORT");
        var database = Environment.GetEnvironmentVariable("DB_NAME");
        var user = Environment.GetEnvironmentVariable("DB_USER");
        var password = Environment.GetEnvironmentVariable("DB_PASSWORD");
        
        if (string.IsNullOrEmpty(host) ||
            string.IsNullOrEmpty(port) ||
            string.IsNullOrEmpty(database) ||
            string.IsNullOrEmpty(user) ||
            string.IsNullOrEmpty(password))
        {
            throw new Exception("Faltan variables de entorno para la conexión a la base de datos.");
        }

        var connectionString = $"server={host};port={port};database={database};user={user};password={password}";

        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuraciones para las relaciones y restricciones

        // Relación uno-a-muchos: Astronauts -> Missions
        modelBuilder.Entity<Missions>()
            .HasOne(m => m.Astronauts)
            .WithMany(a => a.Missions)
            .HasForeignKey(m => m.AstronautId)
            .IsRequired();

        // Relación uno-a-muchos: Ships -> Missions
        modelBuilder.Entity<Missions>()
            .HasOne(m => m.Ship)
            .WithMany(s => s.Missions)
            .HasForeignKey(m => m.ShipId)
            .IsRequired();

        // Relación uno-a-muchos: Missions -> ExplorationLogs
        modelBuilder.Entity<ExplorationLogs>()
            .HasOne(el => el.Mission)
            .WithMany(m => m.ExplorationLogs)
            .HasForeignKey(el => el.MissionId)
            .IsRequired();
        
    }
}