
namespace IADocumentClassifier.Infrastructure.Data.Configurations
{
    using IADocumentClassifier.Cors.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RolesClientConfiguration : IEntityTypeConfiguration<RolesClient>
    {
        public void Configure(EntityTypeBuilder<RolesClient> builder)
        {
            //Mapeo de las entidades configuradas en el Context
            builder.ToTable("RolesClient");

            builder.HasKey(e => e.RolesClient_Id);
            builder.Property(e => e.RolesClient_Id)
               .HasColumnName("RolesClient_Id")
               .IsRequired(); 

            builder.Property(e => e.Client_Id)
                .HasColumnName("Client_Id")
                .IsRequired();

            builder.Property(e => e.Rol_Id)
               .HasColumnName("Rol_Id")
               .IsRequired();

            builder.Property(e => e.Status)
                .HasColumnName("Status")
                .IsRequired();
        }
    }
}
