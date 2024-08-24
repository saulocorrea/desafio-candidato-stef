import { FormControl } from "@angular/forms"

export class PedidoModel {
    id!: number
    nomeCliente!: string
    emailCliente!: string
    pago!: boolean
    valorTotal!: number
    itensPedido!: PedidoItemModel[]
}

export class PedidoItemModel {
    id!: number
    idProduto!: number
    nomeProduto!: number
    valorUnitario!: number
    quantidade!: number
}

export interface PedidoCadastroForm {
    id: FormControl<number | null>,
    nomeCliente: FormControl<string | null>,
    emailCliente: FormControl<string | null>,
    pago: FormControl<boolean | null>,
    valorTotal: FormControl<number | null>,
}