import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Produits2Component } from './produits2.component';

describe('Produits2Component', () => {
  let component: Produits2Component;
  let fixture: ComponentFixture<Produits2Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Produits2Component ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Produits2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
