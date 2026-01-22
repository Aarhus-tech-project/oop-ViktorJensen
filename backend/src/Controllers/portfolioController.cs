using backend.src.Models;
using backend.src.services;
using Microsoft.AspNetCore.Mvc;

namespace backend.src.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PortfolioController : ControllerBase
{
    private readonly PortfolioService _portfolioService;

    public PortfolioController(PortfolioService portfolioService) =>
        _portfolioService = portfolioService;
    
    [HttpGet("{userId}")]
    public async Task<ActionResult<List<Portfolio>>> GetUserPortfolio(string userId)
    {
        var portfolio = await _portfolioService.GetUserPortfolioAsync(userId);
        return Ok(portfolio);
    }

    [HttpGet("{userId}/summary")]
    public async Task<ActionResult<PortfolioSummary>> GetPortfolioSummary(string userId)
    {
        var summary = await _portfolioService.GetPortfolioSummaryAsync(userId);
        return Ok(summary);
    }
    
    [HttpPost]
    public async Task<ActionResult<Portfolio>> AddToPortfolio([FromBody] Portfolio portfolio)
    {
        portfolio.Id = null;

        portfolio.PurchaseDate = DateTime.UtcNow;

        var created = await _portfolioService.AddToPortfolioAsync(portfolio);

        return CreatedAtAction(
            nameof(GetUserPortfolio),
            new { userId = created.UserId },
            created
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePortfolio(string id, [FromBody] Portfolio portfolio)
    {
        portfolio.Id = id;
        await _portfolioService.UpdatePortfolioAsync(id, portfolio);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveFromPortfolio(string id)
    {
        var success = await _portfolioService.RemoveFromPortfolioAsync(id);
        if (!success)
            return NotFound();
        return NoContent();
    }

}