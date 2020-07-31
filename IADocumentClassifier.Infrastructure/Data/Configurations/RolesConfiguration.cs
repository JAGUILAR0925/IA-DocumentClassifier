
namespace IADocumentClassifier.Infrastructure.Data.Configurations
{
    using IADocumentClassifier.Cors.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RolesConfiguration : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            //Mapeo de las entidades configuradas en el Context
            builder.ToTable("Roles");

            builder.HasKey(e => e.Rol_Id);
            builder.Property(e => e.Rol_Id)
               .HasColumnName("Rol_Id");

            builder.Property(e => e.RolName)
                .HasColumnName("RolName")
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.Status)
                .HasColumnName("Status")
                .IsRequired();
        }
    }
}
