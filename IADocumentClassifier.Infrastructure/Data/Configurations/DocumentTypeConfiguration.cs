
namespace IADocumentClassifier.Infrastructure.Data.Configurations
{
    using IADocumentClassifier.Cors.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentsType>
    {
        public void Configure(EntityTypeBuilder<DocumentsType> builder)
        {
           //Mapeo de las entidades configuradas en el Context
            builder.ToTable("DocumentType");

            builder.HasKey(e => e.DocumentTypeId);
            builder.Property(e => e.DocumentTypeId)
               .HasColumnName("DocumentTypeId");
                
            builder.Property(e => e.DocumentType)
                .HasColumnName("DocumentType")
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.Status)
                .HasColumnName("Status")
                .IsRequired();
        }
    }
}
