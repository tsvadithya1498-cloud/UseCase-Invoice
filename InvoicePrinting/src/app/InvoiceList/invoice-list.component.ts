import { Component, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { map } from 'rxjs/operators';

import { InvoiceService } from '../InvoiceService/invoice-service';
import { InvoiceModel } from './invoice-list.model';

@Component({
    selector : 'invoice-list',
    templateUrl : 'invoice-list.component.html'
})
export class InvoiceList {
     @ViewChild('invoiceList') invoiceList : NgForm;
     isFetching:boolean = false;
     isExists = false;
     isError = false;
     invoiceModel : InvoiceModel[];    

    constructor(private invoiceService : InvoiceService){
    }

    onSubmit(){
        this.isExists = false;
        this.isError = false;
        this.invoiceService
        .fetchInvoiceList(this.invoiceList.value.companyId)
        .subscribe(
            responseData => {
                this.isExists = true;
                this.invoiceModel = responseData;
            },
            error =>{
                this.isError = true;
            }
        );
    }    
}