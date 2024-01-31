import { Component } from '@angular/core';

@Component({
  selector: 'app-validation',
  templateUrl: './validation.component.html',
  styleUrls: ['./validation.component.css']
})
export class ValidationComponent {
prixtotal: any;
ngOnInit(): void {
  if(sessionStorage.getItem("prix")!=null){
    this.prixtotal=sessionStorage.getItem("prix");
  }
  sessionStorage.removeItem("panier");
}
}
