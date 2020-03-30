using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace InvoiceAPI.Models
{
    public class CompanyViewModel
    {
        public string CompanyId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide Company Name")]
        [MaxLength(50)]
        [Display(Name ="Company Name")]
        public string CompanyName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide Address")]
        [MaxLength(50)]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }
        
        [MaxLength(50)]
        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide City")]
        [MaxLength(20)]
        public string City { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide State")]
        [MaxLength(15)]
        public string State { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide Zipcode")]
        public int Zipcode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide Country")]
        [MaxLength(20)]
        public string Country { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }
    }
}