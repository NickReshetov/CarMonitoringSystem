using CarsStatusesGenerator.Dtos;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace CarsStatusesGenerator.DataAccess
{
    public class StatusRepository : IStatusRepository
    {
        public async Task SendStatusAsync(StatusDto statusDto)
        {
            using (var client = new HttpClient())
            {
                var uri = new Uri($"https://localhost:44314/api/car/{statusDto.Id}/status");

                var jsonInString = JsonSerializer.Serialize(statusDto);

                var result = await client.PostAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json"));

                string resultContent = await result.Content.ReadAsStringAsync();
            }
        }
    }
}
