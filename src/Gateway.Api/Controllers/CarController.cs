using Gateway.Dtos;
using Gateway.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Gateway.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly IStorageService _storageService;

        public CarController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpPost]
        [Route("{id:Guid}/status")]
        public async Task UpdateStatusAsync(Guid id, StatusDto statusDto) => await _storageService.UpdateStatusAsync(id, statusDto);
    }
}
