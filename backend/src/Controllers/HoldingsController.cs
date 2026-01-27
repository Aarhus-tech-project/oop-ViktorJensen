using backend.src.Models;
using backend.src.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.src.Controllers;

[ApiController]
[Route("api/portfolio")]
public class HoldingsController : ControllerBase
{
    private readonly HoldingsService _holdingsService;

    public HoldingsController(HoldingsService holdingsService)
    {
        _holdingsService = holdingsService;
    }

    [HttpPost("{userId}/holdings")]
    [AllowAnonymous]
    public async Task<ActionResult> AddHolding(
        string userId,
        [FromBody] AddHoldingRequest request)
    {
        await _holdingsService.AddHoldingAsync(userId, request);
        return Ok(new { message = "Holding added successfully" });
    }
}
