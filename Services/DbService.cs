using ExampleTest2.Data;
using ExampleTest2.DTOs;
using ExampleTest2.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<GalleryDTO> GetGalleryByIdAsync(int id)
    {
        Gallery? gallery = await _context.Galleries
            .Include(g => g.Exhibitions)
            .ThenInclude(e => e.ExhibitionArtworks)
            .ThenInclude(ea => ea.Artwork)
            .ThenInclude(a => a.Artist)
            .FirstOrDefaultAsync(g => g.GalleryId == id);

        if (gallery == null) return null;

        GalleryDTO dto = new GalleryDTO
        {
            galleyId = gallery.GalleryId,
            name = gallery.Name,
            establishmentDate = gallery.EstablishedDate,
            exihibitions = gallery.Exhibitions.Select(e => new ExhibitionDTO
            {
                title = e.Title,
                startDate = e.StartDate,
                endDate = e.EndDate,
                numberOfArtowrks = e.NumberOfArtworks,
                artworks = e.ExhibitionArtworks.Select(ea => new ArtworkDTO
                {
                    title = ea.Artwork.Title,
                    yearCreated = ea.Artwork.YearCreated,
                    insuranceValue = ea.InsuranceValue,
                    artist = new ArtistDTO
                    {
                        firstName = ea.Artwork.Artist.FirstName,
                        lastName = ea.Artwork.Artist.LastName,
                        birthDate = ea.Artwork.Artist.BithDate,
                    }
                }).ToList()

            }).ToList()

        };
        return dto;
    }
    
    
    public async Task<bool> AddExhibitionWithArtworksAsync(NewExhibitionDTO dto)
    {
        if (dto.artworks == null || dto.gallery == null) return false;
        
        bool exists = await _context.Exhibitions
            .AnyAsync(e => e.Title == dto.title);

        if (exists) throw new Exception("DuplicateTitle");

        List<Artwork> allArtworks = await _context.Artworks.ToListAsync();
        var invalid = dto.artworks
            .FirstOrDefault(ap => allArtworks.All(p => p.Title == ap.title));
        if (invalid == null) throw new Exception("InvalidTitle");
        
        var exhibition = new Exhibition
        {
            Title = dto.title,
            StartDate = dto.startDate,
            EndDate = dto.endDate,
        };
        await _context.Exhibitions.AddAsync(exhibition);
        await _context.SaveChangesAsync();

        foreach (var a in dto.artworks)
        {
            var artwork = allArtworks.First(p => p.Title == a.title);
            var artworkExhibition = new ExhibitionArtwork
            {
                ArtworkId = artwork.ArtworkId,
                // nie zdażyłem
            };
            await  _context.ExhibitionArtworks.AddAsync(artworkExhibition);
        }
        await _context.SaveChangesAsync();
        return true;
    }
    
}