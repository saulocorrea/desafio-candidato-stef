import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PedidoPesquisaComponent } from './pedido-pesquisa.component';

describe('PedidoPesquisaComponent', () => {
  let component: PedidoPesquisaComponent;
  let fixture: ComponentFixture<PedidoPesquisaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PedidoPesquisaComponent]
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
