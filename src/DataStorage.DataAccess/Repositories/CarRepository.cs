using System;
using System.Threading.Tasks;
using AutoMapper;
using DataStorage.DataAccess.EntityFramework;
using DataStorage.DataAccess.EntityFramework.Interfaces;
using DataStorage.DataAccess.Repositories.Interfaces;
using DataStorage.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataStorage.DataAccess.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly DataStorageDbContext _context;

        private readonly IMapper _mapper;

        public CarRepository(IDataStorageDbContextDbContextFactory contextFactory, IMapper mapper)
        {
            _context = contextFactory.CreateDbContext();

            _mapper = mapper;
        }

        public async Task UpdateStatusAsync(Guid id, StatusDto statusDto)
        {
            var updatingCar = await _context.Cars.SingleOrDefaultAsync(c => c.Id == id);

            updatingCar.LastConnectionTime = statusDto.SentTime;

            _context.Cars.Update(updatingCar);

            await _context.SaveChangesAsync();
        }
    }
}
