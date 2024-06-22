using Domain.Publishing.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Shared.Context;

public class ArtisaniaDBContext:DbContext
{
    public ArtisaniaDBContext()
    {
    }
    
    public ArtisaniaDBContext(DbContextOptions<ArtisaniaDBContext> options):base(options)
    {
    }
    
    public DbSet<Customer>Customers { get; set; }
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=localhost,3306;Uid=root;pwd=12345678;Database=Artisania", serVersion);
        }
    }
    
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Customer>().ToTable("Customers");
        builder.Entity<Customer>().HasKey(c=>c.Id);
        builder.Entity<Customer>().Property(c=>c.Usuario).IsRequired();
        builder.Entity<Customer>().Property(c=>c.ContraseñaHashed).IsRequired();
        builder.Entity<Customer>().Property(c=>c.Correo).IsRequired();
        builder.Entity<Customer>().Property(c=>c.IsArtisan).IsRequired();
    }
}