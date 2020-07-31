

namespace IADocumentClassifier.Infrastructure.Data.Configurations
{
    using IADocumentClassifier.Cors.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RolesPermissionConfiguration : IEntityTypeConfiguration<RolesPermission>
    {
        public void Configure(EntityTypeBuilder<RolesPermission> builder)
        {
            //Mapeo de las entidades configuradas en el Context
            builder.ToTable("RolesPermission");

            builder.HasKey(e => e.RolPermission_Id);
            builder.Property(e => e.RolPermission_Id)
               .HasColumnName("RolPermission_Id")
               .IsRequired();

            builder.Property(e => e.Rol_Id)
                .HasColumnName("Rol_Id")
                .IsRequired();

            builder.Property(e => e.Permission_Id)
               .HasColumnName("Permission_Id")
               .IsRequired();

            builder.Property(e => e.Status)
                .HasColumnName("Status")
                .IsRequired();
        }
    }
}
