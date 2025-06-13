using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Models;

[Table("Exhibition_Artwork")]
[PrimaryKey(nameof(ExhibitionId), nameof(ArtworkId))]
public class ExhibitionArtwork
{
    public int ExhibitionId { get; set; }
    public int ArtworkId { get; set; }
    [DataType("decimal")]
    [Precision(10,2)]
    public decimal InsuranceValue { get; set; }
    
    [ForeignKey(nameof(ExhibitionId))]
    public Exhibition Exhibition { get; set; }
    [ForeignKey(nameof(ArtworkId))]
    public Artwork Artwork { get; set; }
}