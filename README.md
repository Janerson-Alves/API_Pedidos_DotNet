# WebAPI de Gestão de Pedidos

Esta é uma API desenvolvida em **ASP.NET Core** para gerenciar pedidos de uma loja. A API permite criar pedidos, adicionar e remover produtos de um pedido, listar pedidos, consultar um pedido específico e fechar pedidos. Este projeto foi criado para fins de estudo e demonstração.

## Funcionalidades

### Endpoints Disponíveis

#### 1. Criar um novo pedido
- **Rota:** `POST /api/PedidosControllers/iniciar-pedido`
- **Descrição:** Cria um novo pedido sem produtos associados.
- **Entrada:**
  ```json
  {
      "nome": "string",
      "endereco": "string",
      "telefone": "string",
      "email": "string",
      "status": "Aberto"
  }
  ```
- **Saída:**
  ```json
  {
      "id": 0,
      "nome": "string",
      "endereco": "string",
      "telefone": "string",
      "email": "string",
      "status": "Aberto"
  }
  ```

#### 2. Adicionar produtos a um pedido
- **Rota:** `PUT /api/PedidosControllers/adicionar-produtos/{id}`
- **Descrição:** Adiciona produtos a um pedido existente.
- **Entrada:**
  ```json
  [
      "Produto 1",
      "Produto 2"
  ]
  ```
- **Saída:**
  ```json
  {
      "id": 0,
      "nome": "string",
      "endereco": "string",
      "telefone": "string",
      "email": "string",
      "produto": [
          "Produto 1",
          "Produto 2"
      ],
      "status": "Aberto"
  }
  ```

#### 3. Remover produtos de um pedido
- **Rota:** `PUT /api/PedidosControllers/remover-produtos/{id}`
- **Descrição:** Remove produtos de um pedido existente.
- **Entrada:**
  ```json
  [
      "Produto 1"
  ]
  ```
- **Saída:**
  ```json
  {
      "id": 0,
      "nome": "string",
      "endereco": "string",
      "telefone": "string",
      "email": "string",
      "produto": [
          "Produto 2"
      ],
      "status": "Aberto"
  }
  ```

#### 4. Fechar um pedido
- **Rota:** `PUT /api/PedidosControllers/fechar-pedido/{id}`
- **Descrição:** Fecha um pedido existente. Um pedido só pode ser fechado se contiver produtos.
- **Saída:**
  ```json
  {
      "id": 0,
      "nome": "string",
      "endereco": "string",
      "telefone": "string",
      "email": "string",
      "produto": [
          "Produto 1",
          "Produto 2"
      ],
      "status": "Fechado"
  }
  ```

#### 5. Listar todos os pedidos
- **Rota:** `GET /api/PedidosControllers/listar-pedidos`
- **Descrição:** Retorna uma lista com todos os pedidos cadastrados.
- **Saída:**
  ```json
  [
      {
          "id": 0,
          "nome": "string",
          "endereco": "string",
          "telefone": "string",
          "email": "string",
          "produto": [
              "Produto 1"
          ],
          "status": "Aberto"
      }
  ]
  ```

#### 6. Obter pedido por ID
- **Rota:** `GET /api/PedidosControllers/Obter-Pedido-Por-Id/{id}`
- **Descrição:** Retorna os detalhes de um pedido específico com base no ID fornecido.
- **Saída:**
  ```json
  {
      "id": 0,
      "nome": "string",
      "endereco": "string",
      "telefone": "string",
      "email": "string",
      "produto": [
          "Produto 1",
          "Produto 2"
      ],
      "status": "Aberto"
  }
  ```

## Tecnologias Utilizadas

- **Linguagem:** C#
- **Framework:** ASP.NET Core
- **Banco de Dados:** Entity Framework Core
- **Ferramentas:**
  - Swagger para documentação da API

## Estrutura do Projeto

- **Entities:** Contém as classes principais representando as entidades do sistema (e.g., `Pedido`).
- **DTOs:** Contém os Data Transfer Objects usados para transferir dados entre a API e o cliente.
- **Controllers:** Contém os endpoints para interação com a API.
- **Context:** Gerencia o banco de dados usando o Entity Framework Core.

## Como Executar o Projeto

1. **Clone o repositório:**
   ```bash
   git clone <url-do-repositorio>
   ```

2. **Configure o banco de dados:**
   Certifique-se de configurar o banco no arquivo `appsettings.json` e rodar as migrações:
   ```bash
   dotnet ef database update
   ```

3. **Inicie o servidor:**
   ```bash
   dotnet run
   ```

4. **Acesse o Swagger:**
   Abra o navegador em `http://localhost:5000/swagger` para visualizar e testar os endpoints.

## Bibliotecas Utilizadas
- **Microsoft.AspNetCore.Mvc.NewtonsoftJson (Versão 8.0.0)**: Para integração do ASP.NET Core com o Newtonsoft.Json, permitindo uma melhor manipulação de JSON.
- **Microsoft.AspNetCore.OpenApi (Versão 8.0.11)**: Para habilitar suporte a OpenAPI (Swagger) na aplicação.
- **Microsoft.EntityFrameworkCore.Design (Versão 9.0.0)**: Utilizada para suportar design-time features no Entity Framework Core, como migrações e geração de banco de dados.
- **Microsoft.EntityFrameworkCore.SqlServer (Versão 9.0.0)**: Fornece suporte para usar o SQL Server como banco de dados.
- **Swashbuckle.AspNetCore (Versão 6.0.7)**: Para gerar a documentação Swagger da API de forma simples.

## Estrutura Do Projeto
**Entities: Pedido**

A classe `Pedido` representa um pedido feito por um cliente. Ela contém as propriedades que são essenciais para o gerenciamento dos pedidos na loja. 

**Propriedades:**
- `Id`: Identificador único do pedido.
- `Nome`: Nome do cliente que fez o pedido.
- `Endereco`: Endereço de entrega do pedido.
- `Telefone`: Número de telefone do cliente.
- `Email`: Endereço de e-mail do cliente.
- `Produto`: Lista de produtos relacionados ao pedido (representado como uma string).
- `Status`: Status atual do pedido, como "Aberto" ou "Fechado".

**Anotação:**
- A propriedade `Produto` é decorada com o atributo `DisplayName` para exibir um nome legível, caso necessário para a interface de exibição ou geração de relatórios.

**DTOs**

Os DTOs (Data Transfer Objects) são usados para transferir dados entre a API e o cliente de maneira eficiente, mantendo a estrutura de dados consistente. No seu caso, você tem dois DTOs principais: `PedidoDTO` e `PedidoCreateDTO`.

**PedidoDTO**

O `PedidoDTO` é utilizado para representar um pedido completo, incluindo seus dados e produtos. Ele é retornado quando um pedido é consultado ou listado.

**Propriedades:**
- `Id`: Identificador único do pedido.
- `Nome`: Nome do cliente que fez o pedido.
- `Endereco`: Endereço de entrega do pedido.
- `Telefone`: Número de telefone do cliente.
- `Email`: Endereço de e-mail do cliente.
- `Produto`: Lista de produtos relacionados ao pedido.
- `Status`: Status atual do pedido, como "Aberto" ou "Fechado".

**PedidoCreateDTO**

O `PedidoCreateDTO` é utilizado para criar um novo pedido. Ele contém apenas os dados necessários para a criação de um pedido, sem incluir o identificador ou a lista de produtos, pois esses dados serão definidos mais tarde.

**Propriedades:**
- `Nome`: Nome do cliente que está criando o pedido.
- `Endereco`: Endereço de entrega do pedido.
- `Telefone`: Número de telefone do cliente.
- `Email`: Endereço de e-mail do cliente.
- `Status`: Status inicial do pedido, que é "Aberto" por padrão.

**Context**

O **Contexto** é responsável por fornecer uma ponte entre o banco de dados e a aplicação, permitindo que os dados sejam manipulados de forma fácil e eficiente. O `DbContext` é a classe central que gerencia a interação com o banco de dados, realizando as operações de CRUD.

**OrganizadorContext**

O `OrganizadorContext` herda de `DbContext` e representa o contexto do banco de dados da aplicação. Ele define o **DbSet** que corresponde à tabela de pedidos, permitindo a execução de operações de leitura e gravação.

**O que é um DbSet?**
- O **DbSet** é uma coleção de entidades que são mapeadas para uma tabela no banco de dados. No caso do `OrganizadorContext`, o **DbSet<Pedido>** representa a tabela de pedidos no banco de dados.

**Configuração do Contexto**

O `OrganizadorContext` é configurado através do construtor que recebe um parâmetro `DbContextOptions<OrganizadorContext>`, que é usado para definir as opções de conexão ao banco de dados, como a string de conexão.

#### **Exemplo de Uso**

Ao injetar o `OrganizadorContext` na aplicação, você pode realizar operações como adicionar, atualizar, excluir e consultar dados de pedidos. Por exemplo, a API de pedidos usa esse contexto para salvar e recuperar informações de pedidos do banco de dados.

**Controllers**

Os controllers em uma API são responsáveis por gerenciar as requisições HTTP e realizar as operações necessárias no banco de dados ou em outros componentes da aplicação. No seu caso, o **PedidoController** gerencia os pedidos feitos por clientes.

**PedidoController**

O `PedidoController` lida com as operações de CRUD (Criar, Ler, Atualizar, Deletar) para os pedidos. Ele é responsável por fornecer endpoints para criação de pedidos, adição e remoção de produtos, fechamento de pedidos e consulta de pedidos.

**Endpoints:**

- **`POST /api/pedidos/iniciar-pedido`**: Cria um novo pedido com os dados fornecidos no corpo da requisição. Retorna o pedido criado.
- **`PUT /api/pedidos/adicionar-produtos/{id}`**: Adiciona produtos a um pedido existente. O corpo da requisição deve conter uma lista de produtos. Se o pedido estiver fechado, não será possível adicionar produtos.
- **`PUT /api/pedidos/remover-produtos/{id}`**: Remove produtos de um pedido existente. O corpo da requisição deve conter uma lista de produtos a serem removidos. Não é possível remover produtos de um pedido fechado.
- **`PUT /api/pedidos/fechar-pedido/{id}`**: Fecha um pedido, alterando seu status para "Fechado". Não é possível fechar um pedido sem produtos.
- **`GET /api/pedidos/listar-pedidos`**: Retorna todos os pedidos existentes no sistema.
- **`GET /api/pedidos/Obter-Pedido-Por-Id/{id}`**: Retorna um pedido específico com base no seu ID.

**Lógica de operação**

1. **Iniciar Pedido**: Ao receber um pedido para criação, a API inicializa um novo pedido com dados fornecidos (nome, endereço, telefone, e-mail e status). O campo de produtos é inicialmente vazio.
   
2. **Adicionar Produto**: Um pedido existente pode ter produtos adicionados, desde que seu status não seja "Fechado". A lista de produtos é recebida como um array de strings.

3. **Remover Produto**: Produtos podem ser removidos de um pedido, mas, novamente, isso não é permitido se o pedido estiver fechado.

4. **Fechar Pedido**: Um pedido pode ser fechado, desde que tenha pelo menos um produto. Após o fechamento, o status do pedido é atualizado para "Fechado".

5. **Listar Pedidos**: A API permite listar todos os pedidos existentes, fornecendo uma visão geral de todos os pedidos no sistema.

6. **Obter Pedido por ID**: Um pedido específico pode ser consultado com base no seu ID. A resposta retorna os detalhes do pedido, incluindo a lista de produtos e o status atual.

#### **Exemplo de Resposta**:
Ao criar um pedido, a resposta será um objeto do tipo `PedidoDTO` com o ID do pedido, nome, endereço, telefone, e-mail, lista de produtos (vazia inicialmente) e o status do pedido.


### **Configuração do Banco de Dados**

Este projeto usa o **SQL Server** como banco de dados. A configuração de conexão com o banco de dados é armazenada no arquivo `appsettings.json`.

#### **Configuração no appsettings.json**

No arquivo `appsettings.json`, a string de conexão com o banco de dados é definida na seção `ConnectionStrings`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "ConexaoPadrao": "Server=localhost\\SQLEXPRESS; Initial Catalog=Pedido; Integrated Security=True; TrustServerCertificate=True"
  }
}
```

- **Server**: Indica o servidor onde o SQL Server está rodando. Neste caso, localhost\SQLEXPRESS significa que estamos usando uma instância local do SQL Server chamada SQLEXPRESS.
- **Initial Catalog**: O nome do banco de dados, neste caso, Pedido.
- **Integrated Security**: A autenticação é feita usando as credenciais do Windows.
- **TrustServerCertificate**: Permite a confiança no certificado do servidor de banco de dados, útil em ambientes de desenvolvimento.

## Contribuição

Sinta-se à vontade para abrir issues e enviar pull requests para melhorias neste projeto!

## Autor
Projeto desenvolvido por Janerson Alves.

