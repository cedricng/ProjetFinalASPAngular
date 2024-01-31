import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { ProduitsComponent } from './produits/produits.component';
import { HttpClientModule } from '@angular/common/http';
import { PanierComponent } from './panier/panier.component';
import { FormsModule } from '@angular/forms';
import { RecapComponent } from './recap/recap.component';
import { provideRouter } from '@angular/router';
import { ValidationComponent } from './validation/validation.component';
import { DatePipe } from '@angular/common';
import { Produits2Component } from './produits2/produits2.component';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    ProduitsComponent,
    PanierComponent,
    RecapComponent,
    ValidationComponent,
    Produits2Component
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
