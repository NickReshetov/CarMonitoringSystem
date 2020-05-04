using Gateway.Dtos;
using System;
using System.Threading.Tasks;
using Gateway.DataAccess;

namespace Gateway.Services
{
    public class StorageService : IStorageService
    {
        private readonly IStorageRepository _storageRepository;

        public StorageService(IStorageRepository storageRepository) 
        {
            _storageRepository = storageRepository;
        }

        public Task UpdateStatusAsync(Guid id, StatusDto statusDto) => _storageRepository.UpdateStatusAsync(id, statusDto);
    }
}
