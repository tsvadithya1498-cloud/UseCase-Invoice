using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

using InvoiceAPI.Models;
using Newtonsoft.Json;

namespace InvoiceAPI.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection invoice)
        {

            InvoiceViewModel model = new InvoiceViewModel();
            try
            {
                model.CompanyId = Convert.ToString(invoice["CompanyId"]);
                model.InvoiceId = string.Format("{0}-{1}-{2}", model.CompanyId, DateTime.Now.ToString("yyMMdd"), DateTime.Now.ToString("hhmm"));
                model.Date = Convert.ToDateTime(invoice["Date"]);
                model.BillingContactName = Convert.ToString(invoice["BillingContactName"]);
                model.ShippingContactName = Convert.ToString(invoice["ShippingContactName"]);
                model.ShippingCompanyName = Convert.ToString(invoice["ShippingCompanyName"]);
                model.ShippingAddressLine1 = Convert.ToString(invoice["ShippingAddressLine1"]);
                model.ShippingAddressLine2 = Convert.ToString(invoice["ShippingAddressLine2"]);
                model.ShippingCity = Convert.ToString(invoice["ShippingCity"]);
                model.ShippingState = Convert.ToString(invoice["ShippingState"]);
                model.ShippingZipcode = Convert.ToInt32(invoice["ShippingZipcode"]);
                model.ShippingCountry = Convert.ToString(invoice["ShippingCountry"]);
                model.ShippingPhone = Convert.ToString(invoice["ShippingPhone"]);
                model.ShippingEmail = Convert.ToString(invoice["ShippingEmail"]);
                model.SubTotal = Convert.ToDecimal(invoice["SubTotal"]);
                model.Discount = Convert.ToDecimal(invoice["Discount"]);
                model.GrandTotal = Convert.ToDecimal(invoice["GrandTotal"]);
                model.TaxRate = Convert.ToDecimal(invoice["TaxRate"]);
                model.TaxAmount = Convert.ToDecimal(invoice["TaxAmount"]);
                model.ShippingCharges = Convert.ToDecimal(invoice["ShippingCharges"]);
                model.Balance = Convert.ToDecimal(invoice["Balance"]);
                model.Remarks = Convert.ToString(invoice["Remarks"]);

                string[] Description = Convert.ToString(invoice["Description"]).Split(',');
                string[] Price = Convert.ToString(invoice["Price"]).Split(',');
                string[] Quantity = Convert.ToString(invoice["Quantity"]).Split(',');
                string[] Total = Convert.ToString(invoice["Total"]).Split(',');

                List<InvoiceDetailViewModel> lstDetailsModel = new List<InvoiceDetailViewModel>();
                InvoiceDetailViewModel detailModel;

                for (int i = 0; i < Description.Count(); i++)
                {
                    detailModel = new InvoiceDetailViewModel();
                    detailModel.InvoiceId = model.InvoiceId;
                    if (Convert.ToString(Description[i]) == null || string.IsNullOrEmpty(Convert.ToString(Description[i])))
                        continue;
                    detailModel.Description = Convert.ToString(Description[i]);
                    detailModel.Price = Convert.ToDecimal(Price[i]);
                    detailModel.Quantity = Convert.ToInt32(Quantity[i]);
                    detailModel.Total = Convert.ToDecimal(Total[i]);
                    lstDetailsModel.Add(detailModel);
                }

                model.lstInvoiceDetails = lstDetailsModel;
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "An error ocurred while processing data. Please make sure right format of data has been provided in all fields");
            }
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44343/api/invoice/");
                    var postTask = client.PostAsJsonAsync<InvoiceViewModel>("PostNewInvoice", model);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<string>();
                        readTask.Wait();

                        ModelState.Clear();
                        ViewBag.Message = string.Format("{0} - {1}", "Invoice has been inserted successfully. Invoice Number", model.InvoiceId);
                        return View();
                    }
                }

                ModelState.AddModelError(string.Empty, "An error ocurred. Please try again later/contact administrator.");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error ocurred. Please try again later/contact administrator.");
            }
            
            return View();
        }
    }
}