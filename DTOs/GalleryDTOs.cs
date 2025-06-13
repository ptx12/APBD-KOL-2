using ExampleTest2.Models;

namespace ExampleTest2.DTOs;

public class GalleryDTO
{
    public int galleyId { get; set; }
    public string name {get; set;}
    public DateTime establishmentDate { get; set; }
    public List<ExhibitionDTO> exihibitions { get; set; }
}

public class ExhibitionDTO
{
    public string title { get; set; }
    public DateTime startDate { get; set; }
    public DateTime? endDate { get; set; }
    public int numberOfArtowrks { get; set; }
    
    public List<ArtworkDTO> artworks { get; set; }
}
public class ArtworkDTO
{
    public string title { get; set; }
    public int yearCreated { get; set; }
    public decimal insuranceValue { get; set; }
    public ArtistDTO artist { get; set; }
}
public class ArtistDTO
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public DateTime birthDate { get; set; }
}
