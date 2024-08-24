import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PedidoPesquisaComponent } from './components/pedido/pedido-pesquisa/pedido-pesquisa.component';
import { PedidoCadastroComponent } from './components/pedido/pedido-cadastro/pedido-cadastro.component';
import { ProdutoPesquisaComponent } from './components/produto/produto-pesquisa/produto-pesquisa.component';
import { ProdutoCadastroComponent } from './components/produto/produto-cadastro/produto-cadastro.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    PedidoPesquisaComponent,
    PedidoCadastroComponent,
    ProdutoPesquisaComponent,
    ProdutoCadastroComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
