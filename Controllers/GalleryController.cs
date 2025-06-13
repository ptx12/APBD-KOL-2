using ExampleTest2.DTOs;
using ExampleTest2.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExampleTest2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IDbService _dbService;

    public OrdersController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpGet("{id}/exhibitions")]
    public async Task<IActionResult> GetGallery(int id)
    {
        var order = await _dbService.GetGalleryByIdAsync(id);
        
        if (order == null) return NotFound();
        return Ok(order);
    }
}