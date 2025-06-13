using System.ComponentModel.DataAnnotations;

namespace ExampleTest2.Models;

public class Artist
{
    [Key]
    public int ArtistId { get; set; }
    [MaxLength(100)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    public DateTime BithDate { get; set; }
    
    public ICollection<Artwork> Artworks { get; set; }
}