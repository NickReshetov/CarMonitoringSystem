using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Gateway.Dtos;

namespace Gateway.DataAccess
{
    public class StorageRepository : IStorageRepository
    {      
        public async Task UpdateStatusAsync(Guid id, StatusDto statusDto)
        {
            using var client = new HttpClient();

            var uri = new Uri($"https://localhost:44387/api/car/{id}/status");

            var jsonInString = JsonSerializer.Serialize(statusDto);

            var result = await client.PostAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json"));

            string resultContent = await result.Content.ReadAsStringAsync();
        }
    }
}
