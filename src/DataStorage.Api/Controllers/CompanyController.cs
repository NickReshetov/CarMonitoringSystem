using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataStorage.Services;
using DataStorage.Dtos;
using DataStorage.Services.Interfaces;

namespace DataStorage.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public IEnumerable<CompanyDto> GetCompanies() => _companyService.GetCompanies();

        [HttpGet("{companyId:guid}")]
        public async Task<CompanyDto> GetCompanyAsync(Guid companyId) => await _companyService.GetCompanyAsync(companyId);

        [HttpGet("car/status/{status:int}")]
        public IEnumerable<CompanyDto> GetCompanies(int status)
        {
            var statusEnum = (StatusEnum)status;

            var convertedStatus = statusEnum.ToString();

            return _companyService.GetCompanies(convertedStatus);
        }
    }
}
