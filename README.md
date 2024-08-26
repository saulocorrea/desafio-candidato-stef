# Gerenciamento de Pedidos

## Instalação

- Roda em ambiente local
- VisualStudio 2022 para a API
- Iniciar o frontend com os comandos a seguir, dentro da pasta \frontend\WebPedido
  - `npm i`
  - `ng build`
  - `npm start`

## Especificações do projeto

- REST API
- Domain-Driven Design
- Test Driven Development
- UI - Angular

### Framework

net8.0

### Libraries

- Ardalis.Specification Version="8.0.0"
- Microsoft.EntityFrameworkCore Version="8.0.8"
- Microsoft.EntityFrameworkCore.InMemory Version="8.0.8"
- FluentValidation Version="11.9.2"

# Frontend

- Angular 18
- Listagem e cadastro de produtos está completo
- Listagem de pedidos está completo
- TODO: cadastro de pedido

![image](https://github.com/user-attachments/assets/f406888b-e531-4517-a458-fd8a7eb5c45a)

![image](https://github.com/user-attachments/assets/87de3a1d-43d4-4bf8-a5c9-7aeb99838412)

![image](https://github.com/user-attachments/assets/a5c398bf-c8cd-46d7-a6e2-b497f94a8635)

# Pedido.Api

## Download da collection Postman

![image](https://github.com/user-attachments/assets/843653c1-dcf2-4c88-b553-cd05ae3c99c0)

===> [Teste_Pedidos.postman_collection.json](https://github.com/user-attachments/files/16748804/Teste_Pedidos.postman_collection.json)


![image](https://github.com/user-attachments/assets/cffe2d88-d713-451d-8002-c36e2e9ecda3)

# Pedidos

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


# Produtos

![image](https://github.com/user-attachments/assets/74082d1d-4917-42f1-8595-127e628f02c2)


## Buscar todos os produtos

### Request

    GET /produto

### Response

```json
[
  {
    "id": 0,
    "nomeProduto": "string",
    "valor": 0
  }
]
```

## Buscar um produto específico

### Request

    GET /produto/:idProduto

### Response

```json
{
  "id": 0,
  "nomeProduto": "string",
  "valor": 0
}
```

## Buscar um produto inexistente

### Request

    GET /produto/99999

### Response

    HTTP/1.1 404 Not Found
    
    Produto 99999 não encontrado

## Criar um novo produto

### Request

```json
POST /produto

{
  "id": 0,
  "nomeProduto": "string",
  "valor": 0
}
```

### Response

    HTTP/1.1 201 Created

    {
      "id": 22,
      "nomeProduto": "Teclado",
      "valor": 150.99
    }

## Deletar um produto

### Request

`DELETE /produto/:idProduto`

### Response

    HTTP/1.1 204 No Content
