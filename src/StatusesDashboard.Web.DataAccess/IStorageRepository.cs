using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataStorage.Dtos;

namespace StatusesDashboard.Web.DataAccess
{
    public interface IStorageRepository
    {
        Task<IEnumerable<CompanyDto>> GetCompanies();
        
        Task<CompanyDto> GetCompanyAsync(Guid companyId);

        Task<IEnumerable<CompanyDto>> GetCompanies(int status);
    }
}
