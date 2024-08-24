import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PedidoService } from '../../../services/pedido.service';
import { PedidoCadastroForm, PedidoModel } from '../../../models/pedido.model';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-pedido-cadastro',
  templateUrl: './pedido-cadastro.component.html',
  styleUrl: './pedido-cadastro.component.css'
})
export class PedidoCadastroComponent implements OnInit {

  id!: number;
  pedido!: PedidoModel;

  form!: FormGroup<PedidoCadastroForm>;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder,
    private pedidoService: PedidoService) {
  }

  ngOnInit(): void {
    this.id = +this.route.snapshot.paramMap.get('id')!;

    this.form = this.fb.group<PedidoCadastroForm>({
      id: new FormControl(null),
      nomeCliente: new FormControl(''),
      emailCliente: new FormControl(''),
      pago: new FormControl(),
      valorTotal: new FormControl(),
    });

    if (this.id) {
      this.pedidoService.obterPorId(this.id)
        .subscribe(data => {
          this.pedido = data;
        });
    }
  }

  salvar() {

    const dados = this.form.getRawValue();

    if (this.id > 0) {
      this.pedidoService.alterar(this.id, dados)
        .subscribe(data => {
          this.pedido = data;
        });
    } else {
      this.pedidoService.adicionar(dados)
        .subscribe(data => {
          this.pedido = data;
        });
    }
  }

}
