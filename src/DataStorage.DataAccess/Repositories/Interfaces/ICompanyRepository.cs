using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataStorage.Dtos;

namespace DataStorage.DataAccess.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        IEnumerable<CompanyDto> GetCompanies();

        Task<CompanyDto> GetCompanyAsync(Guid companyId);

        IEnumerable<CompanyDto> GetCompanies(string status);
    }
}
