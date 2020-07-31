
namespace IADocumentClassifier.Infrastructure.Data.Configurations
{
    using IADocumentClassifier.Cors.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PermissionsConfiguration : IEntityTypeConfiguration<Permissions>
    {
        public void Configure(EntityTypeBuilder<Permissions> builder)
        {
            //Mapeo de las entidades configuradas en el Context
            builder.ToTable("Permissions");

            builder.HasKey(e => e.Permissions_Id);
            builder.Property(e => e.Permissions_Id)
               .HasColumnName("Permissions_Id");

            builder.Property(e => e.PermissionsName)
                .HasColumnName("PermissionsName")
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.Status)
                .HasColumnName("Status")
                .IsRequired();
        }
    }
}
