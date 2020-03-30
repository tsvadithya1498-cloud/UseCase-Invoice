import { Component, Input, OnInit } from '@angular/core';
import { InvoiceModel } from '../InvoiceList/invoice-list.model';
import {} from '../InvoiceService/invoice-service';

@Component({
    selector : 'invoice-print',
    templateUrl : 'invoice-print.component.html'
})
export class InvoicePrint implements OnInit{
    @Input() invoiceModel : InvoiceModel;

    ngOnInit(){
        this.invoiceModel = new InvoiceModel();
    }    

    onSubmit(){
        window.print();
    }
}