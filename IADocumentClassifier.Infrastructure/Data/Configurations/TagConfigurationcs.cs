
namespace IADocumentClassifier.Infrastructure.Data.Configurations
{
    using IADocumentClassifier.Cors.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TagConfigurationcs : IEntityTypeConfiguration<Tags>
    {
        public void Configure(EntityTypeBuilder<Tags> builder)
        {
            //Mapeo de las entidades configuradas en el Context
            builder.ToTable("Tags");

            builder.HasKey(e => e.Tag_Id);
            builder.Property(e => e.Tag_Id)
               .HasColumnName("Tag_Id");

            builder.Property(e => e.TagName)
                .HasColumnName("TagName")
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.Status)
                .HasColumnName("Status")
                .IsRequired();
        }
    }
}
