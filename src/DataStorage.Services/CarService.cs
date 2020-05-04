using System;
using System.Threading.Tasks;
using DataStorage.DataAccess.Repositories.Interfaces;
using DataStorage.Dtos;
using DataStorage.Services.Interfaces;

namespace DataStorage.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository) 
        {
            _carRepository = carRepository;
        }

        public Task UpdateStatusAsync(Guid id, StatusDto statusDto) => _carRepository.UpdateStatusAsync(id, statusDto);
    }
}
