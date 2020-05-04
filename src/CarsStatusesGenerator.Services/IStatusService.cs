using CarsStatusesGenerator.Dtos;
using System.Threading.Tasks;

namespace CarsStatusesGenerator.Services
{
    public interface IStatusService
    {       
        Task SendStatusAsync(StatusDto statusDtos);
    }
}
