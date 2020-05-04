using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataStorage.DataAccess.EntityFramework;
using DataStorage.DataAccess.EntityFramework.Entities;
using DataStorage.DataAccess.EntityFramework.Interfaces;
using DataStorage.DataAccess.Repositories.Interfaces;
using DataStorage.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace DataStorage.DataAccess.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DataStorageDbContext _context;

        private readonly IMapper _mapper;

        public CompanyRepository(IDataStorageDbContextDbContextFactory contextFactory, IMapper mapper)
        {
            _context = contextFactory.CreateDbContext();

            _mapper = mapper;
        }

        public IEnumerable<CompanyDto> GetCompanies()
        {
            var companyEntities = GetCompanyEntities();

            var companyDtos = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);

            return companyDtos;
        }

        public async Task<CompanyDto> GetCompanyAsync(Guid companyId)
        {
            var companyEntities = GetCompanyEntities();

            var company = await companyEntities.SingleOrDefaultAsync(c => c.Id == companyId);

            var companyDto = _mapper.Map<CompanyDto>(company);

            return companyDto;
        }

        public IEnumerable<CompanyDto> GetCompanies(string status)
        {
            var companyEntities = GetCompanyEntities();

            var companyDtos = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);

            var filteredCompanyDtos = companyDtos
                .Where(company => company.Cars.Any(car => car.Status == status))
                .Select(company => new CompanyDto
                {
                    Id = company.Id,
                    Address = company.Address,
                    Name = company.Name,
                    Cars = company.Cars.Where(car => car.Status == status).ToList()
                })
                .ToList();

            return filteredCompanyDtos;
        }

        private IIncludableQueryable<Company, ICollection<Car>> GetCompanyEntities()
        {
            return _context
                .Companies
                .AsNoTracking()
                .Include(c => c.Cars);
        }
    }
}
