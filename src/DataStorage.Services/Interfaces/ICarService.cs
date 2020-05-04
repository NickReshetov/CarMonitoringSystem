using System;
using System.Threading.Tasks;
using DataStorage.Dtos;

namespace DataStorage.Services.Interfaces
{
    public interface ICarService
    {
        Task UpdateStatusAsync(Guid id, StatusDto statusDto);
    }
}
