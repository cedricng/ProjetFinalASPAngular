import { ChangeDetectorRef, Component } from '@angular/core';
import { Commande } from '../commande';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { formatDate, getLocaleDateTimeFormat } from '@angular/common';
import { DatePipe } from '@angular/common';
import { Client } from '@app/_models';

@Component({
  selector: 'app-recap',
  templateUrl: './recap.component.html',
  styleUrls: ['./recap.component.css']
})
export class RecapComponent {
  getKeys(map:Map<Number,Number>){
    return Array.from(map.keys());
}
Valider() {
let c=new Commande();
c.idClient=Number((<Client>JSON.parse(localStorage.getItem("client")!)).id);
c.date=this.datepipe.transform(Date.now(), 'yyyy-MM-dd');
c.infos=JSON.stringify(Array.from(this.panier.entries()));
c.prixTotal=this.prixTotal();
sessionStorage.setItem("prix",c.prixTotal.toString());
const body=JSON.stringify(c);
   
    this.http.post("http://localhost:64728/api/Commande",body,{
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    }).subscribe(response => {

     
      this.router.navigate(['panier/validation']);


    },

      err => {
       
       console.log("erreur de creation commande")
      });

  }



Retour() {
  this.router.navigate(['panier']);

}
prixTotal(): number {
  let sub=0;
  for (const info of this.panier) {
   sub+=this.findArticle(info[0]).prix * info[1];
  }
  return sub;
 }
  panier: Map<number,number>=new Map<number,number>;
  Mylist : any;
  
  constructor(private http: HttpClient,private changeDetection: ChangeDetectorRef,private router: Router, public datepipe: DatePipe) { }
  findArticle(id:number):any{
 
    for (const art of this.Mylist) {
     if(art.id == id){
       return art;
     }
    }
    return null;
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

    if(window.sessionStorage.getItem("panier")==null){
      window.sessionStorage.setItem("panier",JSON.stringify(Array.from(this.panier.entries())));
    }
    else{
      this.panier=new Map<number,number>(JSON.parse(window.sessionStorage.getItem("panier")!));
      console.log("recap panier");
    }
    console.log("recap");
    console.log(this.panier);
}
}

