import { HttpClient } from '@angular/common/http';
import { ChangeDetectorRef, Component } from '@angular/core';
import { Commande } from '../commande';
import { Router } from '@angular/router';

@Component({
  selector: 'app-panier',
  templateUrl: './panier.component.html',
  styleUrls: ['./panier.component.css']
})
export class PanierComponent {
  
  Mylist : any;
  panier: Map<number,number>=new Map<number,number>;
quantite: number=0;
Recap() {
  this.router.navigate(['panier/recap']);

}
selectedValue: any;
Increment(id:number):void {

  
    let a=this.panier.get(id)
    console.log(a);
    this.panier.set(id,a!+1);
    this.changeDetection.detectChanges();

  window.sessionStorage.setItem("panier",JSON.stringify(Array.from(this.panier.entries())));
    return;
  
 
  
}
Decrement(id:number):void {

  
  let a=this.panier.get(id)
  if(a!>1){
  console.log(a);
  this.panier.set(id,a!-1);
  this.changeDetection.detectChanges();

window.sessionStorage.setItem("panier",JSON.stringify(Array.from(this.panier.entries())));
  return;
  }
  else{
    this.panier.delete(id);
    this.changeDetection.detectChanges();

window.sessionStorage.setItem("panier",JSON.stringify(Array.from(this.panier.entries())));
  return;
  }


}

Ajouter():void {
  console.log(this.selectedValue);
  console.log(this.quantite);
  console.log(this.panier.size);
  if(this.panier.size==undefined){
    this.panier= new Map<number,number>([
      [ this.selectedValue.id, this.quantite ], 
     
    ]);
    this.changeDetection.detectChanges();

    console.log(this.panier);

    window.sessionStorage.setItem("panier",JSON.stringify(Array.from(this.panier.entries())));
    return;
  }
  if(this.panier.has(this.selectedValue.id)){
    let a=this.panier.get(this.selectedValue.id)
    console.log(a);
    this.panier.set(this.selectedValue.id,a!+this.quantite);
    this.changeDetection.detectChanges();

  window.sessionStorage.setItem("panier",JSON.stringify(Array.from(this.panier.entries())));
    return;
  }
  this.panier.set(this.selectedValue.id,this.quantite);
  this.changeDetection.detectChanges();

window.sessionStorage.setItem("panier",JSON.stringify(Array.from(this.panier.entries())));
  
}


  constructor(private http: HttpClient,private changeDetection: ChangeDetectorRef,private router: Router) { }

findArticle(id:number):any{
 if(this.Mylist!=undefined){
 for (const art of this.Mylist) {
  if(art.id == id){
    return art;
  }
 }}
 return null;
}
prixTotal(): number {
  let sub=0;
  for (const info of this.panier) {
   sub+=this.findArticle(info[0]).prix * info[1];
  }
  return sub;
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
    }
}
}
