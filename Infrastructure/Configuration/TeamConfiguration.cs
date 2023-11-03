using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities;

namespace Data.Configuration
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("team");

            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.HasIndex(e => e.Name, "equipos_Nombre_IDX").IsUnique();

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            
            builder
                .HasMany(p=>p.Drivers)
                .WithMany(p=>p.Teams)
                .UsingEntity<TeamDriver>(
                j=>j
                .HasOne(pt=>pt.Driver)
                .WithMany(t=>t.TeamsDrivers)
                .HasForeignKey(pt=>pt.IdDriver),
            j => j
                .HasOne(pt => pt.Team)
                .WithMany(t => t.TeamsDrivers)
                .HasForeignKey(pt => pt.IdTeam),
            j => 
            {
                j.HasKey(t => new { t.IdTeam, t.IdDriver});
                j.ToTable("teamdriver");
            }
            );
        }
    }
}