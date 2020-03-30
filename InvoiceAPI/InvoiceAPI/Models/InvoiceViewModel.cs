using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace InvoiceAPI.Models
{
    public class InvoiceViewModel
    {
		public string InvoiceId { get; set; }
		
		[Required(ErrorMessage ="Please provide company id")]
		[MaxLength(20)]
		public string CompanyId { get; set; }

		[Required(ErrorMessage = "Please provide Invoice date")]
		public DateTime Date { get; set; }

		[MaxLength(25)]
		[Display(Name = "Billing Contact Name")]
		public string BillingContactName { get; set; }

		[MaxLength(25)]
		[Display(Name = "Shipping Contact Name")]
		public string ShippingContactName { get; set; }

		[Required(ErrorMessage = "Please provide Shipping company name")]
		[MaxLength(50)]
		[Display(Name = "Shipping Company Name")]
		public string ShippingCompanyName { get; set; }

		[Required(ErrorMessage = "Please provide Shipping address")]
		[MaxLength(50)]
		[Display(Name = "Shipping Address Line 1")]
		public string ShippingAddressLine1 { get; set; }

		[MaxLength(50)]
		[Display(Name = "Shipping Address Line 2")]
		public string ShippingAddressLine2 { get; set; }

		[Required(ErrorMessage = "Please provide Shipping city")]
		[MaxLength(20)]
		[Display(Name = "Shipping City")]
		public string ShippingCity { get; set; }

		[Required(ErrorMessage = "Please provide Shipping state")]
		[MaxLength(15)]
		[Display(Name = "Shipping State")]
		public string ShippingState { get; set; }

		[Required(ErrorMessage = "Please provide Shipping Zipcode")]
		[Display(Name = "Shipping Zip code")]
		public int ShippingZipcode { get; set; }

		[Required(ErrorMessage = "Please provide Shipping country")]
		[MaxLength(20)]
		[Display(Name = "Shipping Country")]
		public string ShippingCountry { get; set; }

		[Display(Name = "Shipping Phone")]
		[MaxLength(20)]
		public string ShippingPhone { get; set; }

		[MaxLength(50)]
		[Display(Name = "Shipping Email")]
		public string ShippingEmail { get; set; }

		[Required(ErrorMessage = "Please provide ")]
		public decimal SubTotal { get; set; }

		public decimal? Discount { get; set; }

		[Required(ErrorMessage = "Please provide ")]
		[Display(Name = "Grand Total (Subtotal - Discount)")]
		public decimal GrandTotal { get; set; }

		[Display(Name = "Tax Rate")]
		public decimal? TaxRate { get; set; }

		[Display(Name = "Tax Amount")]
		public decimal? TaxAmount { get; set; }

		[Display(Name = "Shipping Charges")]
		public decimal? ShippingCharges { get; set; }

		[Required(ErrorMessage = "Please provide Balance")]
		public decimal Balance { get; set; }

		public string Remarks { get; set; }

		public List<InvoiceDetailViewModel> lstInvoiceDetails { get; set; }
	}
}