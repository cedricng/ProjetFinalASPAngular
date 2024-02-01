import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { ProduitsComponent } from './produits/produits.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { PanierComponent } from './panier/panier.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegisterComponent } from './account/register/register.component';
import { LoginComponent } from './account/login/login.component';
import { ClientComponent } from './client/client.component';
import { HomeComponent } from './home/home/home.component';
import { ErrorInterceptor, JwtInterceptor } from './_helpers';
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
    RegisterComponent,
    LoginComponent,
    ClientComponent,
    HomeComponent,
    RecapComponent,
    ValidationComponent,
    Produits2Component
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserModule,
    ReactiveFormsModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
