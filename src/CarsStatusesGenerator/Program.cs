using CarsStatusesGenerator.Dtos;
using CarsStatusesGenerator.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsStatusesGenerator
{
    class Program
    {
        private static IStatusService _statusService;
        private const int sendingIntervalInSeconds = 60;

        static void Main(string[] args)
        {
            Console.WriteLine("Status sender has been started!");

            _statusService = new StatusService();

            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromSeconds(sendingIntervalInSeconds);

            var timer = new System.Threading.Timer(async (e) =>
            {
                await SendStatusesAsync();
            }, null, startTimeSpan, periodTimeSpan);

            Console.ReadLine();
        }

        private static async Task SendStatusesAsync()
        {
            var statusDtos = GetCarsStatuses();

            foreach (var statusDto in statusDtos)
            {
                await _statusService.SendStatusAsync(statusDto);
                Console.WriteLine($"Status for {statusDto.Id} has been sent at {statusDto.SentTime.TimeOfDay}");
            }

            Console.WriteLine("---------------------------------------------------------------------------------");
        }

        private static IEnumerable<StatusDto> GetCarsStatuses()
        {
            var carsStatuses = new List<StatusDto>
            {
                new StatusDto { Id = new Guid("9cfcf01d-2fc2-4421-ba92-161e26523ec7"), SentTime = DateTime.UtcNow },
                new StatusDto { Id = new Guid("f3010824-b306-4f47-9b4b-63e9f2df9dbb"), SentTime = DateTime.UtcNow },
                new StatusDto { Id = new Guid("60d63d29-bbd5-415b-baf9-fbb30d1931ec"), SentTime = DateTime.UtcNow },
                new StatusDto { Id = new Guid("6d11f4ce-7f40-409a-b32d-4361623facd0"), SentTime = DateTime.UtcNow },
                new StatusDto { Id = new Guid("2d2acf5e-b851-4b82-b9fd-fc6d7e891a8a"), SentTime = DateTime.UtcNow },
                new StatusDto { Id = new Guid("6af83221-c82f-4dd3-a347-10ed8c987024"), SentTime = DateTime.UtcNow },
                new StatusDto { Id = new Guid("9271d334-c22c-4f4f-a6d4-c33508669015"), SentTime = DateTime.UtcNow }                
            };

            var random = new Random();
            var offlineCarIndex = random.Next(0, 6);

            carsStatuses.RemoveAt(offlineCarIndex);

            return carsStatuses;
        }
    }
}
