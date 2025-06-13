using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleTest2.Models;

public class Exhibition
{
    [Key]
    public int ExhibitionId { get; set; }
    public int GalleryId { get; set; }
    
    [ForeignKey(nameof(GalleryId))]
    public Gallery? Gallery { get; set; }
    
    [MaxLength(100)]
    public string Title { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    
    public int NumberOfArtworks { get; set; }
    
    public ICollection<ExhibitionArtwork> ExhibitionArtworks { get; set; }
}