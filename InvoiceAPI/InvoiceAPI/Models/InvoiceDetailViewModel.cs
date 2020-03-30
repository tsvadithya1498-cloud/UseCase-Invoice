using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceAPI.Models
{
    public class InvoiceDetailViewModel
    {
		public int InvoiceDetailId { get; set; }

		public string InvoiceId { get; set; }

		public string Description { get; set; }

		public decimal Price { get; set; }

		public int Quantity { get; set; }

		public decimal Total { get; set; }
	}
}