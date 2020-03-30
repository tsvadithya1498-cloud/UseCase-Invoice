using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using InvoiceAPI.DAL;
using InvoiceAPI.Repository;
using InvoiceAPI.Models;

namespace InvoiceAPI.Controllers.API
{
    [RoutePrefix("api/invoice")]
    public class InvoiceController : ApiController
    {
        private InvoiceRepository _invoiceRepository;
        public InvoiceController()
        {
            _invoiceRepository = new InvoiceRepository();
        }

        [Route("GetByCompanyId")]
        public IList<InvoiceViewModel> GetByCompanyId(string companyId)
        {
            return _invoiceRepository.GetByCompanyId(companyId)
                .Select(i => new InvoiceViewModel()
                {
                    InvoiceId = i.InvoiceId,
                    BillingContactName = i.BillingContactName,
                    GrandTotal = i.GrandTotal,
                }).ToList<InvoiceViewModel>();
        }

        [Route("GetByInvoiceId")]
        public InvoiceViewModel GetByInvoiceId(string invoiceId)
        {
            InvoiceViewModel invoiceViewModel = new InvoiceViewModel();
            List<InvoiceDetailViewModel> lstDetailModel = new List<InvoiceDetailViewModel>();
            InvoiceDetailViewModel detailModel;

            var result = _invoiceRepository.GetByInvoiceId(invoiceId);

            invoiceViewModel.InvoiceId = result.InvoiceId;
            invoiceViewModel.CompanyId = result.CompanyId;
            invoiceViewModel.Date = result.Date;
            invoiceViewModel.BillingContactName = result.BillingContactName;
            invoiceViewModel.ShippingContactName = result.ShippingContactName;
            invoiceViewModel.ShippingCompanyName = result.ShippingCompanyName;
            invoiceViewModel.ShippingAddressLine1 = result.ShippingAddressLine1;
            invoiceViewModel.ShippingAddressLine2 = result.ShippingAddressLine2;
            invoiceViewModel.ShippingCity = result.ShippingCity;
            invoiceViewModel.ShippingState = result.ShippingState;
            invoiceViewModel.ShippingZipcode = result.ShippingZipcode;
            invoiceViewModel.ShippingCountry = result.ShippingCountry;
            invoiceViewModel.ShippingPhone = result.ShippingPhone;
            invoiceViewModel.ShippingEmail = result.ShippingEmail;
            invoiceViewModel.SubTotal = result.SubTotal;
            invoiceViewModel.Discount = result.Discount;
            invoiceViewModel.GrandTotal = result.GrandTotal;
            invoiceViewModel.TaxRate = result.TaxRate;
            invoiceViewModel.TaxAmount = result.TaxAmount;
            invoiceViewModel.ShippingCharges = result.ShippingCharges;
            invoiceViewModel.Balance = result.Balance;
            invoiceViewModel.Remarks = result.Remarks;

            foreach (var temp in result.InvoiceDetails)
            {
                detailModel = new InvoiceDetailViewModel();
                detailModel.InvoiceDetailId = temp.InvoiceDetailId;
                detailModel.InvoiceId = temp.InvoiceId;
                detailModel.Description = temp.Description;
                detailModel.Price = temp.Price;
                detailModel.Quantity = temp.Quantity;
                detailModel.Total = temp.Total;
                lstDetailModel.Add(detailModel);
            }

            invoiceViewModel.lstInvoiceDetails = lstDetailModel;

            return invoiceViewModel;
        }

        [Route("PostNewInvoice")]
        public string PostNewInvoice(InvoiceViewModel invoiceViewModel)
        {
            InvoiceDetail detail;
            List<InvoiceDetail> lstdetail = new List<InvoiceDetail>();
            foreach (InvoiceDetailViewModel model in invoiceViewModel.lstInvoiceDetails)
            {
                detail = new InvoiceDetail();
                detail.InvoiceId = model.InvoiceId;
                detail.Description = model.Description;
                detail.Price = model.Price;
                detail.Quantity = model.Quantity;
                detail.Total = model.Total;
                lstdetail.Add(detail);
            }

            _invoiceRepository.Insert(new Invoice()
            {
                InvoiceId = invoiceViewModel.InvoiceId,
                CompanyId = invoiceViewModel.CompanyId,
                Date = invoiceViewModel.Date,
                BillingContactName = invoiceViewModel.BillingContactName,
                ShippingContactName = invoiceViewModel.ShippingContactName,
                ShippingCompanyName = invoiceViewModel.ShippingCompanyName,
                ShippingAddressLine1 = invoiceViewModel.ShippingAddressLine1,
                ShippingAddressLine2 = invoiceViewModel.ShippingAddressLine2,
                ShippingCity = invoiceViewModel.ShippingCity,
                ShippingState = invoiceViewModel.ShippingState,
                ShippingZipcode = invoiceViewModel.ShippingZipcode,
                ShippingCountry = invoiceViewModel.ShippingCountry,
                ShippingPhone = invoiceViewModel.ShippingPhone,
                ShippingEmail = invoiceViewModel.ShippingEmail,
                SubTotal = invoiceViewModel.SubTotal,
                Discount = invoiceViewModel.Discount,
                GrandTotal = invoiceViewModel.GrandTotal,
                TaxRate = invoiceViewModel.TaxRate,
                TaxAmount = invoiceViewModel.TaxAmount,
                ShippingCharges = invoiceViewModel.ShippingCharges,
                Balance = invoiceViewModel.Balance,
                Remarks = invoiceViewModel.Remarks,
                InvoiceDetails = lstdetail,
            });

            return invoiceViewModel.InvoiceId;
        }
    }
}
