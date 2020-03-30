export class InvoiceModel {
    InvoiceId : string;
    CompanyId : string;
    CompanyName : string;
    Date : Date;
    BillingContactName : string;
    ShippingContactName : string;
    ShippingCompanyName : string;
    ShippingAddressLine1 : string;
    ShippingAddressLine2 : string;
    ShippingCity : string;
    ShippingState : string;
    ShippingZipcode : number;
    ShippingCountry : string;
    ShippingPhone : string;
    ShippingEmail : string;
    SubTotal : number;
    Discount : number;    
    GrandTotal : number;
    TaxRate : number;
    TaxAmount : number;
    ShippingCharges : number;
    Balance : number;
    Remarks : string;
    lstInvoiceDetails : any[];
}