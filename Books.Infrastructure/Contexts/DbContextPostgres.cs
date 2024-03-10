using Books.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Books.Infrastructure.Contexts;

public class DbContextPostgres : DbContext
{
    public DbContextPostgres(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
    }

    public DbSet<Book> Books { get; set; }
}