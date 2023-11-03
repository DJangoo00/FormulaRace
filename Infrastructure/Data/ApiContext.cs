using System;
using System.Collections.Generic;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public partial class ApiContext : DbContext
{
    public ApiContext()
    {
    }

    public ApiContext(DbContextOptions<ApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=123456;database=formularace", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("driver");

            entity.HasIndex(e => e.IdTeam, "driver_FK");

            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("team");

            entity.HasIndex(e => e.Name, "equipos_Nombre_IDX").IsUnique();

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasMany(d => d.IdDrivers).WithMany(p => p.IdTeams)
                .UsingEntity<Dictionary<string, object>>(
                    "Teamdriver",
                    r => r.HasOne<Driver>().WithMany()
                        .HasForeignKey("IdDriver")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("teamdriver_FK_1"),
                    l => l.HasOne<Team>().WithMany()
                        .HasForeignKey("IdTeam")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("teamdriver_FK"),
                    j =>
                    {
                        j.HasKey("IdTeam", "IdDriver")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("teamdriver");
                        j.HasIndex(new[] { "IdDriver" }, "teamdriver_FK_1");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
