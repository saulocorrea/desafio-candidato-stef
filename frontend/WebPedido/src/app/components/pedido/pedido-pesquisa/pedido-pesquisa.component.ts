import { Component, OnInit } from '@angular/core';
import { PedidoModel } from '../../../models/pedido.model';
import { PedidoService } from '../../../services/pedido.service';

@Component({
  selector: 'app-pedido-pesquisa',
  templateUrl: './pedido-pesquisa.component.html',
  styleUrl: './pedido-pesquisa.component.css'
})
export class PedidoPesquisaComponent implements OnInit {

  constructor(private pedidoService: PedidoService) { }

  pedidos: PedidoModel[] = [];

  ngOnInit(): void {
    this.carregarPedidos();
  }

  deletar(id: number): void {
    const deletar = confirm('Realmente deseja deletar o pedido?');

    if (!deletar) {
      return;
    }

    this.pedidoService.deletar(id)
      .subscribe({
        next: (_: any) => {
          this.carregarPedidos();
        },
        error: (err: any) => { }
      });
  }

  carregarPedidos(): void {
    this.pedidoService.obterTodos()
      .subscribe({
        next: (retorno: any[]) => {
          this.pedidos = retorno;
        },
        error: (err: any) => {
          this.pedidos = [];
        }
      });
  }
}

