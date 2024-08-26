import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProdutoCadastroForm, ProdutoModel } from '../../../models/produto.model';
import { ProdutoService } from '../../../services/produto.service';

@Component({
  selector: 'app-produto-cadastro',
  templateUrl: './produto-cadastro.component.html',
  styleUrl: './produto-cadastro.component.css'
})
export class ProdutoCadastroComponent {
  id!: number;
  produto!: ProdutoModel;

  form!: FormGroup<ProdutoCadastroForm>;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder,
    private produtoService: ProdutoService) {
  }

  ngOnInit(): void {
    this.id = +this.route.snapshot.paramMap.get('id')! || 0;

    this.form = this.fb.group<ProdutoCadastroForm>({
      id: new FormControl(this.id),
      nomeProduto: new FormControl('', Validators.required),
      valor: new FormControl(0, Validators.required),
    });

    if (this.id > 0) {
      this.produtoService.obterPorId(this.id)
        .subscribe(data => {
          this.produto = data;
          this.form.patchValue(data);
        });
    }
  }

  salvar() {

    const dados = this.form.getRawValue();

    if (this.id > 0) {
      this.produtoService.alterar(this.id, dados)
        .subscribe(data => {
          this.produto = data;
          this.router.navigate(['produto']);
        });
    } else {
      this.produtoService.adicionar(dados)
        .subscribe(data => {
          this.produto = data;
          this.router.navigate(['produto']);
        });
    }
  }
}
