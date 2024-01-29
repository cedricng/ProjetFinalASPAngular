import { Component } from '@angular/core';
import { HttpClient } from  '@angular/common/http';


@Component({
  selector: 'app-produits',
  templateUrl: './produits.component.html',
  styleUrls: ['./produits.component.css']
})
export class ProduitsComponent {
  Mylist : any;

  constructor(private http: HttpClient) { }

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
