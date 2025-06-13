namespace ExampleTest2.DTOs;

public class NewExhibitionDTO
{
    public string title { get; set; }
    public string gallery { get; set; } // name
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
    public List<ArtworkDTO> artworks { get; set; }
}

public class ArtworkCreateDTO
{
    public int artworkId { get; set; }
    public decimal insuranceValue { get; set; }
}