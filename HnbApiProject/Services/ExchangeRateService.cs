using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using HnbApiProject.Models;

// Service class responsible for fetching exchange rate data from an external API.
public class ExchangeRateService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    // Constructor that initializes the HttpClient and IConfiguration instances.
    public ExchangeRateService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    // Asynchronously fetches exchange rates for a given date range using API settings configured in appsettings.json.
    public async Task<List<ExchangeRate>> GetExchangeRatesAsync(string fromDate, string toDate)
    {
        string baseUrl = _configuration.GetValue<string>("ExchangeRateApi:BaseUrl");
        string queryParamFromDate = _configuration.GetValue<string>("ExchangeRateApi:QueryParamFromDate");
        string queryParamToDate = _configuration.GetValue<string>("ExchangeRateApi:QueryParamToDate");

        var url = $"{baseUrl}?{queryParamFromDate}={fromDate}&{queryParamToDate}={toDate}";

        HttpResponseMessage response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var data = await response.Content.ReadFromJsonAsync<List<ExchangeRate>>(jsonOptions);
        return data ?? new List<ExchangeRate>();
    }
}
