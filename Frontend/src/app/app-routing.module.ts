import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProduitsComponent } from './produits/produits.component';
import { PanierComponent } from './panier/panier.component';
import { RecapComponent } from './recap/recap.component';
import { ValidationComponent } from './validation/validation.component';
import { Produits2Component } from './produits2/produits2.component';

const routes: Routes = [
  {path:'produits',component:ProduitsComponent},
  {path:'produits2',component:Produits2Component},
  {path:'panier',component:PanierComponent},
  {path:'panier/recap',component:RecapComponent},
  {path:'panier/validation',component:ValidationComponent},
  {path:'',component:ProduitsComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
