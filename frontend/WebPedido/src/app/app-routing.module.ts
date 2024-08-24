import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PedidoPesquisaComponent } from './components/pedido/pedido-pesquisa/pedido-pesquisa.component';
import { ProdutoPesquisaComponent } from './components/produto/produto-pesquisa/produto-pesquisa.component';
import { PedidoCadastroComponent } from './components/pedido/pedido-cadastro/pedido-cadastro.component';
import { ProdutoCadastroComponent } from './components/produto/produto-cadastro/produto-cadastro.component';

const routes: Routes = [
  {
    path: 'pedido',
    component: PedidoPesquisaComponent,
  },
  {
    path: 'pedido/:id',
    component: PedidoCadastroComponent,
  },
  {
    path: 'pedido/novo',
    component: PedidoCadastroComponent,
  },
  {
    path: 'produto',
    component: ProdutoPesquisaComponent,
  },
  {
    path: 'produto/:id',
    component: ProdutoCadastroComponent,
  },
  {
    path: 'produto/novo',
    component: ProdutoCadastroComponent,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
