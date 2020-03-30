using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using InvoiceAPI.Models;
using InvoiceAPI.DAL;

namespace InvoiceAPI.Repository
{
    public class InvoiceRepository
    {
        private readonly InvoiceDBContext _context;

        public InvoiceRepository()
        {
            _context = new InvoiceDBContext();
        }

        public InvoiceRepository(InvoiceDBContext context)
        {
            context = _context;
        }

        public List<Invoice> GetByCompanyId(string companyId)
        {
            return _context.Invoices
                .Where(i => i.CompanyId.Equals(companyId))
                .ToList();
        }

        public Invoice GetByInvoiceId(string invoiceId)
        {
            //return _context.Invoices
            //    .Include("InvoiceDetails")
            //    .Where(i => i.InvoiceId.Equals(invoiceId))
            //    .ToList();               

            return _context.Invoices
                 .Include("InvoiceDetails")
                 .Where(i => i.InvoiceId.Equals(invoiceId))
                 .FirstOrDefault();
        }

        public string Insert(Invoice invoice)
        {
            _context.Invoices
                .Add(invoice);

            _context.SaveChanges();

            return invoice.InvoiceId;
        }
    }
}