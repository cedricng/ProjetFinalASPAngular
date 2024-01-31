import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProduitsComponent } from './produits/produits.component';
import { PanierComponent } from './panier/panier.component';
import { LoginComponent } from './account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { HomeComponent } from './home/home/home.component';
import { AuthGuard } from './_helpers';

const routes: Routes = [

  { path: '', component: HomeComponent, canActivate: [AuthGuard]  },
  { path:'produits',component:ProduitsComponent},
  { path:'panier',component:PanierComponent},
  { path: 'account/login', component: LoginComponent },
  { path: 'account/register', component: RegisterComponent },
    // otherwise redirect to home
    { path: '**', redirectTo: '' }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
