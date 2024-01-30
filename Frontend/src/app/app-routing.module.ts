import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProduitsComponent } from './produits/produits.component';
import { PanierComponent } from './panier/panier.component';

const routes: Routes = [
  {path:'produits',component:ProduitsComponent},
  {path:'panier',component:PanierComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
