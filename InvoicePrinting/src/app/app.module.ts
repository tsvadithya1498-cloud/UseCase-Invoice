import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { Routes, RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { InvoiceGeneration } from  './InvoiceGeneration/invoice-generation.component';
import { InvoiceList } from './InvoiceList/invoice-list.component';
import { LoadingSpinner } from './LoadingSpinner/loading-spinner.component';
import { InvoicePrint } from './InvoicePrint/invoice-print.component';

const routes : Routes = [
  { path : '', component : InvoiceGeneration },
  { path : 'InvoiceGeneration', component : InvoiceGeneration},
  { path : 'InvoiceList', component : InvoiceList }
]

@NgModule({
  declarations: [
    AppComponent,
    InvoiceGeneration,
    InvoiceList,
    LoadingSpinner,
    InvoicePrint
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes),
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
