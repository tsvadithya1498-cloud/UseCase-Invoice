import { Component, ViewChild, OnInit } from '@angular/core';
import { InvoiceService } from '../InvoiceService/invoice-service';
import { NgForm } from '@angular/forms';
import { InvoiceModel } from '../InvoiceList/invoice-list.model';

@Component({
    selector : 'invoice-generation',
    templateUrl : 'invoice-generation.component.html'
})
export class InvoiceGeneration {
    @ViewChild('invoiceGeneration') invoiceGeneration : NgForm;
    isError : boolean;
    invoiceModel : InvoiceModel;
    invoiceId : string;

    constructor(private invoiceService : InvoiceService){
    }

    onSubmit(){
        this.isError = false;
        this.invoiceModel = new InvoiceModel();
        this.invoiceService
        .fetchInvoiceDetails(this.invoiceGeneration.value.invoiceId)
        .subscribe(responseData =>{
            this.invoiceModel = responseData;
        },
        error => {
            this.isError = true;
        });
    }
}