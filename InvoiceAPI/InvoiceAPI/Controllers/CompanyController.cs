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
    public class CompanyController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(CompanyViewModel company)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:44343/api/company/");

                        var postTask = client.PostAsJsonAsync<CompanyViewModel>("PostNewCompany", company);
                        postTask.Wait();

                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadAsAsync<string>();
                            readTask.Wait();

                            ModelState.Clear();
                            ViewBag.Message = string.Format("{0} - {1}. {2}", "Company has been registered successfully. Company Id", readTask.Result , " (Please note down the company id in order to create invoice)");
                            return View();
                        }
                    }

                    ModelState.AddModelError(string.Empty, "An error ocurred. Please try again later/contact administrator.");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error ocurred. Please try again later/contact administrator.");
                }
            }
            return View();
        }
    }
}