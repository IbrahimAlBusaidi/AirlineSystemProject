using CodelineAirlines.Shared.Models.DTOs.AirportDTOs;
using Newtonsoft.Json;

namespace CodelineAirlines.Website.Services.WeatherForecast
{
    public class AirportAdditionService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7205";

        public AirportAdditionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AddNewAirport(AirportControllerInputDTO airportControllerInput)
        {
            using HttpClient httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };
            var postResponse = await httpClient.PostAsJsonAsync("/api/Airport/AddAirport", airportControllerInput);
            if (postResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Airport added successfully!");
                return true;
            }
            else
            {
                Console.WriteLine($"Error: {postResponse.StatusCode}");
                return false;
            }
        }
    }
}
