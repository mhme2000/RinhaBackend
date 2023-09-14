using Microsoft.AspNetCore.Mvc;

namespace RinhaBackend.Controllers;

[ApiController]
[Route("pessoas")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] long id)
    {
        
    }
    
}