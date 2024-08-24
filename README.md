# Pedido.Api

![image](https://github.com/user-attachments/assets/7b0a3b8a-323e-4407-8bd8-a1930243f8fc)

## Buscar todos os pedidos

### Request

    GET /pedido

### Response

```json
[
  {
    "id": 0,
    "nomeCliente": "string",
    "emailCliente": "string",
    "pago": true,
    "valorTotal": 0,
    "itensPedido": [
      {
        "id": 0,
        "idProduto": 0,
        "nomeProduto": "string",
        "valorUnitario": 0,
        "quantidade": 0
      }
    ]
  }
]
```

## Buscar um pedido específico

### Request

    GET /pedido/:idPedido

### Response

```json
{
    "id": 0,
    "nomeCliente": "string",
    "emailCliente": "string",
    "pago": true,
    "valorTotal": 0,
    "itensPedido": [{
        "id": 0,
        "idProduto": 0,
        "nomeProduto": "string",
        "valorUnitario": 0,
        "quantidade": 0
    }]
}
```

## Buscar um pedido inexistente

### Request

    GET /pedido/99999

### Response

    HTTP/1.1 404 Not Found
    
    Pedido 1 não encontrado

## Criar um novo pedido

### Request

```json
POST /Pedido

{
  "nomeCliente": "Cliente 1",
  "emailCliente": "cliente1@email.com",
  "pago": true,
  "itensPedido": [
    {
      "idProduto": 1,
      "quantidade": 2
    },
    {
      "idProduto": 4,
      "quantidade": 1
    }
  ]
}
```

### Response

    HTTP/1.1 201 Created

    {
        "id": 2,
        "nomeCliente": "Cliente 1",
        "emailCliente": "cliente1@email.com",
        "pago": false,
        "valorTotal": 859.88,
        "itensPedido": [
            {
                "id": 2,
                "idProduto": 1,
                "nomeProduto": "Mouse Gamer",
                "valorUnitario": 129.99,
                "quantidade": 2
            },
            {
                "id": 3,
                "idProduto": 4,
                "nomeProduto": "SSD 1TB",
                "valorUnitario": 599.9,
                "quantidade": 1
            }
        ]
    }

## Registrar pedido pago

### Request

`PUT /Pedido/:idPedido/setar-pago`

### Response

    HTTP/1.1 200 OK

## Deletar um pedido

### Request

`DELETE /Pedido/:idPedido`

### Response

    HTTP/1.1 204 No Content
