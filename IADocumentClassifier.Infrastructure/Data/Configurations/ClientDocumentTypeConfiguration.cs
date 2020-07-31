
namespace IADocumentClassifier.Infrastructure.Data.Configurations
{
    using IADocumentClassifier.Cors.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ClientDocumentTypeConfiguration : IEntityTypeConfiguration<ClientDocumentType>
    {
        public void Configure(EntityTypeBuilder<ClientDocumentType> builder)
        {
            //Mapeo de las entidades configuradas en el Context
            builder.ToTable("ClientDocumentType");

            builder.HasKey(e => e.ClientDocumentType_Id);
            builder.Property(e => e.ClientDocumentType_Id)
               .HasColumnName("ClientDocumentType_Id")
               .IsRequired();

            builder.Property(e => e.Client_Id)
                .HasColumnName("Client_Id")
                .IsRequired();

            builder.Property(e => e.DocumentType_Id)
               .HasColumnName("DocumentType_Id")
               .IsRequired();

            builder.Property(e => e.Path)
                .HasColumnName("Path")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
