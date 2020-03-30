using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using InvoiceAPI.Models;
using InvoiceAPI.DAL;

namespace InvoiceAPI.Repository
{
    public class CompanyRepository
    {
        private readonly InvoiceDBContext _context;

        public CompanyRepository()
        {
            _context = new InvoiceDBContext();
        }

        public CompanyRepository(InvoiceDBContext context)
        {
            context = _context;
        }
        public List<Company> GetAll()
        {
            return _context.Companies
                .ToList();
        }

        public Company GetById(string companyId)
        {
            return _context.Companies
                .Where(c => c.CompanyId.Equals(companyId))
                .FirstOrDefault();
        }

        public string Insert(Company company)
        {
            bool isExists = true;
            string companyId = string.Empty;
            do
            {
                companyId = GenerateCompanyId().ToUpper();
                isExists = _context.Companies.Any(c => c.CompanyId.Equals(companyId));

            } while (isExists);

            company.CompanyId = companyId;

            _context.Companies
                .Add(company);

            _context.SaveChanges();

            return companyId;
        }

        public string GenerateCompanyId()
        {
            return Guid.NewGuid().ToString().Substring(0, 6);
        }
    }
}
