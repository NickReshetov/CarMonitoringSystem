using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DataStorage.Dtos;

namespace StatusesDashboard.Web.DataAccess
{
    public class StorageRepository : IStorageRepository
    {
        public async Task<IEnumerable<CompanyDto>> GetCompanies()
        {
            var companyDtos = await GetResponseAsync<IEnumerable<CompanyDto>>("https://localhost:44387/api/company");

            return companyDtos;
        }

        public async Task<CompanyDto> GetCompanyAsync(Guid companyId)
        {
            var companyDto = await GetResponseAsync<CompanyDto>($"https://localhost:44387/api/company/{companyId}");

            return companyDto;
        }

        public async Task<IEnumerable<CompanyDto>> GetCompanies(int status)
        {
            var companyDtos = await GetResponseAsync<IEnumerable<CompanyDto>>($"https://localhost:44387/api/company/car/status/{status}");

            return companyDtos;
        }

        private static async Task<T> GetResponseAsync<T>(string url)
        {
            using var httpClient = new HttpClient();

            var uri = new Uri(url);

            var httpResponseMessage = await httpClient.GetAsync(uri);

            httpResponseMessage.EnsureSuccessStatusCode();

            var jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();

            var serializationOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var dto = JsonSerializer.Deserialize<T>(jsonResponse, serializationOptions);

            return dto;
        }
    }
}
