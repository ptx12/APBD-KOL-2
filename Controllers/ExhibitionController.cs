using ExampleTest2.DTOs;
using ExampleTest2.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExampleTest2.Controllers;

[ApiController]
[Route("api/exhibitions")]
public class WashingMachinesController : ControllerBase
{
    private readonly IDbService _dbService;

    public WashingMachinesController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost]
    public async Task<IActionResult> AddExhibition([FromBody] NewExhibitionDTO dto)
    {
        try
        {
            var result = await _dbService.AddExhibitionWithArtworksAsync(dto);
            if (!result) return BadRequest();
            return Ok();
        }
        catch (Exception ex)
        {
            if (ex.Message == "DuplicateTitle") return Conflict("exhibition already exists");
            if (ex.Message == "InvalidTitle") return NotFound("one of the artworks does not exist");
            return StatusCode(500, "Unexpected error.");
        }
    }
}