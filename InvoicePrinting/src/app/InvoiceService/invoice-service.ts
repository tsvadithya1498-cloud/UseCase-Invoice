import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { InvoiceModel } from '../InvoiceList/invoice-list.model';
import { Observable, BehaviorSubject } from 'rxjs';

@Injectable({providedIn : 'root'})
export class InvoiceService{

    private invoiceid = new BehaviorSubject<string>('');
    shareInvoiceId = this.invoiceid.asObservable();

    constructor(private http:HttpClient){
    }

    fetchInvoiceList(companyId:string): Observable<InvoiceModel[]>{
        return this.http.get<InvoiceModel[]>('https://localhost:44343/api/invoice/GetByCompanyId?companyId='+companyId);
    }

    fetchInvoiceDetails(invoideId : string) : Observable<InvoiceModel>{
        return this.http.get<InvoiceModel>('https://localhost:44343/api/invoice/GetByInvoiceId?invoiceId='+invoideId);
    }

    passInvoiceId(invoiceId : string){
        this.invoiceid.next(invoiceId);
    }
}