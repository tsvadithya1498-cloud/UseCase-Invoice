using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using InvoiceAPI.DAL;
using InvoiceAPI.Models;
using InvoiceAPI.Repository;

namespace InvoiceAPI.Controllers.API
{
    [RoutePrefix("api/company")]
    public class CompanyController : ApiController
    {
        private CompanyRepository _companyRepository;
        public CompanyController()
        {
            _companyRepository = new CompanyRepository();
        }

        [Route("PostNewCompany")]
        public string PostNewCompany(CompanyViewModel companyDetails)
        {
            return _companyRepository.Insert(new Company()
            {
                CompanyId = companyDetails.CompanyId,
                CompanyName = companyDetails.CompanyName,
                AddressLine1 = companyDetails.AddressLine1,
                AddressLine2 = companyDetails.AddressLine2,
                City = companyDetails.City,
                State = companyDetails.State,
                Zipcode = companyDetails.Zipcode,
                Country = companyDetails.Country,
                Phone = companyDetails.Phone,
                Email = companyDetails.Email,
            });
        }
    }
}
