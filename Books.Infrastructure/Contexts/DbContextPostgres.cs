using Books.Domain.Entities;
using Books.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Books.Infrastructure.Contexts;

public class DbContextPostgres : DbContext
{
    public DbContextPostgres(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating ( ModelBuilder options )
    {
        options.ApplyConfiguration(new BookConfiguration());
        options.ApplyConfiguration(new AddressConfiguration());
        options.ApplyConfiguration(new LibraryConfiguration());
        base.OnModelCreating(options);
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Library> Librarys { get; set; }
    public DbSet<Address> Address { get; set; }
}