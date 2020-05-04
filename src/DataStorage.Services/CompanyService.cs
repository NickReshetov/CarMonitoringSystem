using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataStorage.DataAccess.Repositories.Interfaces;
using DataStorage.Dtos;
using DataStorage.Services.Interfaces;

namespace DataStorage.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _storageRepository;

        public CompanyService(ICompanyRepository storageRepository) 
        {
            _storageRepository = storageRepository;
        }

        public IEnumerable<CompanyDto> GetCompanies()
        {
            var companyDtos = _storageRepository.GetCompanies();
            
            return companyDtos;
        }

        public IEnumerable<CompanyDto> GetCompanies(string status)
        {
            var companyDtos = _storageRepository.GetCompanies(status);

            return companyDtos;
        }

        public async Task<CompanyDto> GetCompanyAsync(Guid companyId)
        {
            var companyDto = await _storageRepository.GetCompanyAsync(companyId);

            return companyDto;
        }
    }
}
