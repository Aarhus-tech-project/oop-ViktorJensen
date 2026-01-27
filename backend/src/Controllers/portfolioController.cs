using backend.src.Models;
using backend.src.services;
using Microsoft.AspNetCore.Mvc;

namespace backend.src.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PortfolioController(PortfolioService portfolioService) : ControllerBase
{
    private readonly PortfolioService _portfolioService = portfolioService;

    [HttpGet("{id}")]
    public async Task<ActionResult<List<Portfolio>>> GetUserPortfolio(string id)
    {
        var portfolio = await _portfolioService.GetUserPortfolioAsync(id);
        return Ok(portfolio);
    }

    [HttpGet("{id}/summary")]
    public async Task<ActionResult<PortfolioSummary>> GetPortfolioSummary(string id)
    {
        var summary = await _portfolioService.GetPortfolioSummaryAsync(id);
        return Ok(summary);
    }
    
    [HttpPost]
    public async Task<ActionResult<Portfolio>> AddToPortfolio([FromBody] Portfolio portfolio)
    {
        portfolio.Id = null;

        var created = await _portfolioService.AddToPortfolioAsync(portfolio);

        return CreatedAtAction(
            nameof(GetUserPortfolio),
            new { id = created.Id },
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