using Gateway.Dtos;
using System;
using System.Threading.Tasks;

namespace Gateway.Services
{
    public interface IStorageService
    {
        Task UpdateStatusAsync(Guid id, StatusDto statusDto);
    }
}
