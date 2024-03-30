using LibraryApp.Domain.Entities;
using LibraryApp.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApp.Infrastructure.Data.Configuration;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");
        builder.HasKey(x => x.Id);
        
        builder.OwnsOne(x => x.Header, opt =>
        {
            opt.Property(y => y.Title)
                .HasMaxLength(BookHeader.MaxTitleLength)
                .HasColumnName("Title")
                .IsRequired();
            opt.Property(y => y.Description)
                .HasMaxLength(BookHeader.MaxDescriptionLength)
                .HasColumnName("Description")
                .IsRequired(false);
        });
        
        builder.HasOne(x => x.Author)
            .WithMany(y => y.Books)
            .HasForeignKey("AuthorId")
            .IsRequired(false);

        builder.Property(x => x.PublicationDate)
            .HasColumnName("Publication Date")
            .IsRequired();
    }
}