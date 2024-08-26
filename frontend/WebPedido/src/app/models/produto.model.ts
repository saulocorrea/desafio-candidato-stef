import { FormControl } from "@angular/forms"

export class ProdutoModel {
    id!: number
    nomeProduto!: string
    valor!: number
}

export interface ProdutoCadastroForm {
    id: FormControl<number | null>,
    nomeProduto: FormControl<string | null>,
    valor: FormControl<number | null>,
}
