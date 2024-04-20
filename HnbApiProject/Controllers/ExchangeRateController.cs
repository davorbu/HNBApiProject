using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

// API controller that handles incoming HTTP requests to fetch average exchange rates.
[ApiController]
[Route("[controller]")]
public class ExchangeRateController : ControllerBase
{
    private readonly ExchangeRateService _exchangeRateService;

    // Constructor that injects the ExchangeRateService into the controller.
    public ExchangeRateController(ExchangeRateService exchangeRateService)
    {
        _exchangeRateService = exchangeRateService;
    }

    // HTTP GET method to fetch average exchange rates for a specified date range.
    [HttpGet("average")]
    public async Task<IActionResult> GetAverageExchangeRates([FromQuery] string fromDate, [FromQuery] string toDate)
    {
        var rates = await _exchangeRateService.GetExchangeRatesAsync(fromDate, toDate);
        if (!rates.Any())
        {
            return NotFound("No data available for the given period.");
        }

        return Ok(rates);
    }
}
