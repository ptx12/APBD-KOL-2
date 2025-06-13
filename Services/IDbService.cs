using ExampleTest2.DTOs;

namespace ExampleTest2.Services;

public interface IDbService
{
    public Task<GalleryDTO> GetGalleryByIdAsync(int id);
    Task<bool> AddExhibitionWithArtworksAsync(NewExhibitionDTO dto);
}