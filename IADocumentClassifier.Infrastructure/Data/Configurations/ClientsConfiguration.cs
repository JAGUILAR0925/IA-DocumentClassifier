
namespace IADocumentClassifier.Infrastructure.Data.Configurations
{
    using IADocumentClassifier.Cors.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ClientsConfiguration : IEntityTypeConfiguration<Clients>
    {
        public void Configure(EntityTypeBuilder<Clients> builder)
        {
            // Mapeo de las entidades configuradas en el Context
            builder.ToTable("Clients");

            builder.HasKey(e => e.Client_Id);

            builder.Property(e => e.Client_Id)
               .HasColumnName("Client_Id");

            builder.Property(e => e.Name)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.Identification)
               .HasColumnName("Identification")
               .IsRequired();

            builder.Property(e => e.Status)
                .HasColumnName("Status")
                .IsRequired();

            builder.Property(e => e.Token)
                .HasColumnName("Token")
                .HasMaxLength(250)
                .IsRequired();
        }
    }
}
