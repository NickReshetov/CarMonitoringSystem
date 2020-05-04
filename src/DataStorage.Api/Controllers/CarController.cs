using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using DataStorage.Services;
using DataStorage.Dtos;
using DataStorage.Services.Interfaces;

namespace DataStorage.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost]
        [Route("{id:guid}/status")]
        public async Task UpdateStatusAsync(Guid id, StatusDto statusDto) => await _carService.UpdateStatusAsync(id, statusDto);
    }
}
