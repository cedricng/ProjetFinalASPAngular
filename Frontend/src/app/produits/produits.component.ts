import { Component } from '@angular/core';
import { HttpClient } from  '@angular/common/http';
import { Route, Router } from '@angular/router';


@Component({
  selector: 'app-produits',
  templateUrl: './produits.component.html',
  styleUrls: ['./produits.component.css']
})
export class ProduitsComponent {
  Mylist : any;
  panier: Map<number,number>=new Map<number,number>;

  constructor(private http: HttpClient, private router: Router) { }
  Ajouter(id:number):void {
  
    if(this.panier.size==undefined){
      this.panier= new Map<number,number>([
        [ id, 1], 
       
      ]);
  
      console.log(this.panier);
  
      window.sessionStorage.setItem("panier",JSON.stringify(Array.from(this.panier.entries())));
      this.router.navigate(['panier']);
    }
    if(this.panier.has(id)){
      let a=this.panier.get(id)
      console.log(a);
      this.panier.set(id,a!+1);
  
    window.sessionStorage.setItem("panier",JSON.stringify(Array.from(this.panier.entries())));
    this.router.navigate(['panier']);

    }
    this.panier.set(id,1);
  
  window.sessionStorage.setItem("panier",JSON.stringify(Array.from(this.panier.entries())));
  this.router.navigate(['panier']);

  }
  ngOnInit(): void {

    this.http.get("http://localhost:64728/api/article").subscribe(
      (response) => {
        this.Mylist=response;
       
        console.log(response);
      }
      ,
     (err) => {
        console.log("*************KO")
        
      },

      () => {
        console.log("*********complete****")
        
      }

    );
}
}
