import { Component } from '@angular/core';
import { ProdutoService } from '../../../services/produto.service';
import { ProdutoModel } from '../../../models/produto.model';

@Component({
  selector: 'app-produto-pesquisa',
  templateUrl: './produto-pesquisa.component.html',
  styleUrl: './produto-pesquisa.component.css'
})
export class ProdutoPesquisaComponent {
  constructor(private produtoService: ProdutoService) { }

  produtos: ProdutoModel[] = [];

  ngOnInit(): void {
    this.carregarTodos();
  }

  deletar(id: number): void {
    const deletar = confirm('Realmente deseja deletar o produto?');

    if (!deletar) {
      return;
    }

    this.produtoService.deletar(id)
      .subscribe({
        next: (_: any) => {
          this.carregarTodos();
        },
        error: (err: any) => { }
      });
  }

  carregarTodos(): void {
    this.produtoService.obterTodos()
      .subscribe({
        next: (retorno: any[]) => {
          this.produtos = retorno;
        },
        error: (err: any) => {
          this.produtos = [];
        }
      });
  }
}
