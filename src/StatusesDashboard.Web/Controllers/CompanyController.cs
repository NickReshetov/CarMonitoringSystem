using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataStorage.Dtos;
using Microsoft.AspNetCore.Mvc;
using StatusesDashboard.Web.DataAccess;

namespace StatusesDashboard.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly IStorageRepository _storageRepository;

        public CompanyController(IStorageRepository storageRepository)
        {
            _storageRepository = storageRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<CompanyDto>> GetCompanies() => await _storageRepository.GetCompanies();

        [HttpGet("{companyId:guid}")]
        public async Task<CompanyDto> GetCompany(Guid companyId) => await _storageRepository.GetCompanyAsync(companyId);

        [HttpGet("car/status/{status:int}")]
        public async Task<IEnumerable<CompanyDto>> GetCompanies(int status) => await _storageRepository.GetCompanies(status);
    }
}
