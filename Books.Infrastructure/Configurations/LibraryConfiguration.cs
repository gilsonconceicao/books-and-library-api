using Books.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Books.Infrastructure.Configurations
{
    public class LibraryConfiguration : IEntityTypeConfiguration<Library>
    {
        public void Configure(EntityTypeBuilder<Library> builder)
        {
            builder
               .HasMany(e => e.Books)
               .WithOne(e => e.Library)
               .HasForeignKey(e => e.LibraryId)
               .IsRequired();

            builder
               .HasOne(e => e.Address)
               .WithOne(e => e.Library)
               .HasForeignKey<Address>(e => e.LibraryId)
               .IsRequired();
        }
    }
}