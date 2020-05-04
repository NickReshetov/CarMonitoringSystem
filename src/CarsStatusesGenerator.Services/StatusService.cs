using CarsStatusesGenerator.DataAccess;
using CarsStatusesGenerator.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsStatusesGenerator.Services
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;

        public StatusService() 
        {
            _statusRepository = new StatusRepository();
        }
        
        public async Task SendStatusAsync(StatusDto statusDto)
        {
           await _statusRepository.SendStatusAsync(statusDto);
        }        
    }
}
