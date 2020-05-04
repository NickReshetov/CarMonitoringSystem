using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataStorage.Dtos;

namespace DataStorage.Services.Interfaces
{
    public interface ICompanyService
    {
        IEnumerable<CompanyDto> GetCompanies();

        IEnumerable<CompanyDto> GetCompanies(string status);

        Task<CompanyDto> GetCompanyAsync(Guid companyId);
    }
}
