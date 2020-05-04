using System.Threading.Tasks;
using DataStorage.Dtos;

namespace DataStorage.DataAccess.Repositories.Interfaces
{
    public interface ICarRepository
    {
        Task UpdateStatusAsync(System.Guid id, StatusDto statusDto);
    }
}
