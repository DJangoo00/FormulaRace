using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities;

namespace Data.Configuration
{
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("driver");
            
            builder.HasKey(e => e.Id).HasName("PRIMARY");            

            builder.HasIndex(e => e.IdTeam, "driver_FK");

            builder.Property(e => e.Age)
                .HasColumnName("age");

            builder.Property(e => e.Name)
                .HasMaxLength(60)
                .HasColumnName("name");
        }
    }
}