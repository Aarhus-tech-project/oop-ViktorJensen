using backend.src.Models;
using backend.src.services;
using Microsoft.AspNetCore.Mvc;

namespace backend.src.Models;

[ApiController]
[Route("api/[controller]")]
public class StockController : ControllerBase
{
    private readonly StocksService _stocksService;
    public StockController( StocksService stocksService) =>
    _stocksService = stocksService;

    [HttpGet]
    public async Task<List<Stock>> Get() =>
        await _stocksService.GetAsync();
    
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Stock>> Get(string id)
    {
        var Stock = await _stocksService.GetAsync(id);
        if (Stock is null)
        {
            return NotFound();
        }
        return Stock;
    }
}