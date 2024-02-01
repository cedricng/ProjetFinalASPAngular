import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProduitsComponent } from './produits/produits.component';
import { PanierComponent } from './panier/panier.component';
import { LoginComponent } from './account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { HomeComponent } from './home/home/home.component';
import { RecapComponent } from './recap/recap.component';
import { ValidationComponent } from './validation/validation.component';
import { Produits2Component } from './produits2/produits2.component';
import { AuthGuard } from './_helpers';

const routes: Routes = [

  { path: 'home', component: HomeComponent, canActivate: [AuthGuard]  }
  { path: 'account/login', component: LoginComponent },
  { path: 'account/register', component: RegisterComponent },
  { path:'produits',component:ProduitsComponent},
  {path:'produits',component:ProduitsComponent},
  {path:'produits2',component:Produits2Component},
  {path:'panier',component:PanierComponent},
  {path:'panier/recap',component:RecapComponent},
  {path:'panier/validation',component:ValidationComponent},
  {path:'',component:ProduitsComponent}
    // otherwise redirect to home
    { path: '**', redirectTo: '' }


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
