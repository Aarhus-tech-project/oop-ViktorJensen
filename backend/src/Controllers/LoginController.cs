using backend.src.Models;
using backend.src.services;
using Microsoft.AspNetCore.Mvc;

namespace backend.src.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class UserController(UserService userService) : ControllerBase
    {
    private readonly UserService _userService = userService;

    [HttpGet("{username}")]
    public async Task<ActionResult<User>> GetUserByUsernameAsync(string username)
    {
        var User = await _userService.GetUserByUsernameAsync(username);
        if (User is null)
        {
            return NotFound($"Stock with symbol '{username}' not found");
        }
        return Ok(User);
    }
}