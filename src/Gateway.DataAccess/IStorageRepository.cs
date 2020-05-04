using System.Threading.Tasks;
using Gateway.Dtos;

namespace Gateway.DataAccess
{
    public interface IStorageRepository
    {
        Task UpdateStatusAsync(System.Guid id, StatusDto statusDto);
    }
}
