//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InvoiceAPI.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Invoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Invoice()
        {
            this.InvoiceDetails = new HashSet<InvoiceDetail>();
        }
    
        public string InvoiceId { get; set; }
        public string CompanyId { get; set; }
        public System.DateTime Date { get; set; }
        public string BillingContactName { get; set; }
        public string ShippingContactName { get; set; }
        public string ShippingCompanyName { get; set; }
        public string ShippingAddressLine1 { get; set; }
        public string ShippingAddressLine2 { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }
        public int ShippingZipcode { get; set; }
        public string ShippingCountry { get; set; }
        public string ShippingPhone { get; set; }
        public string ShippingEmail { get; set; }
        public decimal SubTotal { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public decimal GrandTotal { get; set; }
        public Nullable<decimal> TaxRate { get; set; }
        public Nullable<decimal> TaxAmount { get; set; }
        public Nullable<decimal> ShippingCharges { get; set; }
        public decimal Balance { get; set; }
        public string Remarks { get; set; }
    
        public virtual Company Company { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
