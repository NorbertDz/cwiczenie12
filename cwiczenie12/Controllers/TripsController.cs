using cwiczenie12.Models.DTO;
using cwiczenie12.Services;
using Microsoft.AspNetCore.Mvc;

namespace cwiczenie12.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TripsController : ControllerBase
{
    private readonly ITripsService _tripsService;

    public TripsController(ITripsService tripsService)
    {
        _tripsService = tripsService;
    }
        
    [HttpGet]
    public async Task<IActionResult> GetTrips([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var result = await _tripsService.GetTrips(page, pageSize);
        return Ok(result);
    }
        
    [HttpPost("{idTrip}/clients")]
    public async Task<IActionResult> AssignClientToTrip(int idTrip, [FromBody] AssignClientDto dto)
    {
        var result = await _tripsService.AssignClientToTrip(idTrip, dto);
        if (!result)
            return BadRequest("Error assigning client to trip. Trip not found or date is in the past.");
        return Ok("Client assigned to trip successfully.");
    }
}