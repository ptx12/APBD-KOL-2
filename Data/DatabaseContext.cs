using System.Reflection.Metadata;
using ExampleTest2.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Data;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Artwork> Clients { get; set; }
    public DbSet<ExhibitionArtwork> ExhibitionArtworks { get; set; }
    public DbSet<Artwork> Artworks { get; set; }
    public DbSet<Exhibition> Exhibitions { get; set; }
    public DbSet<Gallery> Galleries { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<ExhibitionArtwork>()
            .HasKey(e => new {e.ArtworkId, e.ExhibitionId});
        
        modelBuilder.Entity<ExhibitionArtwork>()
            .HasOne(ea => ea.Exhibition)
            .WithMany(e => e.ExhibitionArtworks)
            .HasForeignKey(ea => ea.ExhibitionId);
        
        modelBuilder.Entity<ExhibitionArtwork>()
            .HasOne(ea => ea.Artwork)
            .WithMany(a => a.ArtworkExhibitions)
            .HasForeignKey(ea => ea.ArtworkId);

        modelBuilder.Entity<Exhibition>()
            .HasOne(e => e.Gallery)
            .WithMany(g => g.Exhibitions);
        
        modelBuilder.Entity<Artist>()
            .HasMany(a => a.Artworks)
            .WithOne(a => a.Artist);
        
        modelBuilder.Entity<Gallery>()
            .HasMany(g => g.Exhibitions)
            .WithOne(g => g.Gallery);
    }
}