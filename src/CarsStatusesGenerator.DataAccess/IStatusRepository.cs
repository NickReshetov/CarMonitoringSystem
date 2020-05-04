using CarsStatusesGenerator.Dtos;
using System.Threading.Tasks;

namespace CarsStatusesGenerator.DataAccess
{
    public interface IStatusRepository
    {
        Task SendStatusAsync(StatusDto statusDto);
    }
}
