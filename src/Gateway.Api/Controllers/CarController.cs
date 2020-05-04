using Gateway.Dtos;
using Gateway.Services;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public void UpdateStatusAsync(Guid id, StatusDto statusDto) => _storageService.UpdateStatusAsync(id, statusDto);
    }
}
