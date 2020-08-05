
namespace IADocumentClassifier.Infrastructure.Data.Configurations
{
    using IADocumentClassifier.Cors.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SetupConfiguration : IEntityTypeConfiguration<Setup>
    {
        public void Configure(EntityTypeBuilder<Setup> builder)
        {
            //Mapeo de las entidades configuradas en el Context
            builder.ToTable("Setup");

            builder.HasKey(e => e.Setup_Id);
            builder.Property(e => e.Name)
               .HasColumnName("Name")
               .HasMaxLength(250)
               .IsUnicode(false)
               .IsRequired();

            builder.Property(e => e.ValueParameter)
                .HasColumnName("ValueParameter")
                .HasMaxLength(250)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.Client_Id)
               .HasColumnName("Client_Id")
               .IsRequired();

            builder.Property(e => e.Status)
                .HasColumnName("Status")
                .IsRequired();
        }
    }
}
