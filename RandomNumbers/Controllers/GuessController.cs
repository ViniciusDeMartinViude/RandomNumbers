using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomNumbers.Services;

namespace RandomNumbers.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GuessController : ControllerBase
{
    private readonly IRandomNumber _randomNumberService;

    public class ChooseRequest
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }

    public GuessController(IRandomNumber randomNumberService)
    {
        _randomNumberService = randomNumberService;
    }

    [HttpPost("choose")]
    public async Task<IActionResult> ChooseNewNumber([FromBody] ChooseRequest request)
    {
        if (request.Min >= request.Max)
        {
            return BadRequest("Minimum value must be less than maximum value.");
        }
        await _randomNumberService.ChooseNewNumber(request.Min, request.Max);
        return Ok("A new number has been chosen.");
    }

    [HttpGet("guess")]
    public IActionResult TryGuessNumber([FromQuery] int guess)
    {
        var result = _randomNumberService.TryGuessNumber(guess);
        return Ok(result);
    }
}
