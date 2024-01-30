import { HttpClient } from '@angular/common/http';
import { ChangeDetectorRef, Component } from '@angular/core';
import { Commande } from '../commande';

@Component({
  selector: 'app-panier',
  templateUrl: './panier.component.html',
  styleUrls: ['./panier.component.css']
})
export class PanierComponent {
selectedValue: any;
Ajouter():void {
  console.log(this.selectedValue);
  console.log(this.quantite);
  console.log(this.panier.infos.size);
  if(this.panier.infos.size==undefined){
    this.panier.infos= new Map<number,number>([
      [ this.selectedValue.id, this.quantite ], 
     
    ]);
    this.changeDetection.detectChanges();

    console.log(this.panier.infos);

    sessionStorage.setItem("panier",JSON.stringify(this.panier));
    return;
  }
  if(this.panier.infos.has(this.selectedValue.id)){
    let a=this.panier.infos.get(this.selectedValue.id)
    console.log(a);
    this.panier.infos.set(this.selectedValue.id,a!+this.quantite);
    this.changeDetection.detectChanges();

    sessionStorage.setItem("panier",JSON.stringify(this.panier));
    return;
  }
  this.panier.infos.set(this.selectedValue.id,this.quantite);
  this.changeDetection.detectChanges();

  sessionStorage.setItem("panier",JSON.stringify(this.panier));
  
}

  Mylist : any;
  panier: Commande = new Commande();
quantite: number=0;

  constructor(private http: HttpClient,private changeDetection: ChangeDetectorRef) { }

findArticle(id:number):any{
 
 for (const art of this.Mylist) {
  if(art.id == id){
    return art;
  }
 }
 return null;
}
prixTotal(): number {
  let sub=0;
  for (const info of this.panier.infos) {
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

    if(sessionStorage.getItem("panier")==null){
      sessionStorage.setItem("panier",JSON.stringify(this.panier));
    }
    else{
      this.panier=JSON.parse(sessionStorage.getItem("panier")!);
    }
}
}
