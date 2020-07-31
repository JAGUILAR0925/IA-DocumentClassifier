
namespace IADocumentClassifier.Infrastructure.Data.Configurations
{
    using IADocumentClassifier.Cors.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ClientTagConfiguration : IEntityTypeConfiguration<ClientTag>
    {
        public void Configure(EntityTypeBuilder<ClientTag> builder)
        {
            //Mapeo de las entidades configuradas en el Context
            builder.ToTable("ClientTag");

            builder.HasKey(e => e.ClientTag_Id);
            builder.Property(e => e.ClientTag_Id)
               .HasColumnName("ClientTag_Id")
               .IsRequired();

            builder.Property(e => e.Client_Id)
                .HasColumnName("Client_Id")
                .IsRequired();

            builder.Property(e => e.Tag_Id)
               .HasColumnName("Tag_Id")
               .IsRequired();
        }
    }
}
