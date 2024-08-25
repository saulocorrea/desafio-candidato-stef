import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from '../../../app-routing.module';
import { PedidoPesquisaComponent } from './pedido-pesquisa.component';
import { ProdutoService } from '../../../services/produto.service';

describe('PedidoPesquisaComponent', () => {
  let component: PedidoPesquisaComponent;
  let fixture: ComponentFixture<PedidoPesquisaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PedidoPesquisaComponent],
      imports: [
        FormsModule,
        ReactiveFormsModule,
        BrowserModule,
        AppRoutingModule,
        HttpClientModule
      ],
      providers: [ProdutoService]
    })
      .compileComponents();

    fixture = TestBed.createComponent(PedidoPesquisaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
