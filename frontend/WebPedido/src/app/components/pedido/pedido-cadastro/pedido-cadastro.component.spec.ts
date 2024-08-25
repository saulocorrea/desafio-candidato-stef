import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PedidoCadastroComponent } from './pedido-cadastro.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from '../../../app-routing.module';
import { HttpClientModule } from '@angular/common/http';

describe('PedidoCadastroComponent', () => {
  let component: PedidoCadastroComponent;
  let fixture: ComponentFixture<PedidoCadastroComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PedidoCadastroComponent],
      imports: [
        FormsModule,
        ReactiveFormsModule,
        BrowserModule,
        AppRoutingModule,
        HttpClientModule
      ]
    })
      .compileComponents();

    fixture = TestBed.createComponent(PedidoCadastroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
