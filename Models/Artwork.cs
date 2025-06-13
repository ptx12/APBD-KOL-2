using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleTest2.Models;

public class Artwork
{
    [Key]
    public int ArtworkId { get; set; }
    public int ArtistId { get; set; }
    public string Title { get; set; }
    
    [ForeignKey(nameof(ArtistId))]
    public Artist Artist { get; set; }
    
    public int YearCreated { get; set; }
    
    public ICollection<ExhibitionArtwork> ArtworkExhibitions { get; set; }
}