# Senff-Desafio

A **AluguelCarros API** é uma aplicação para gerenciamento de aluguel de carros, permitindo criar, listar, atualizar, e deletar carros, clientes, e aluguéis. Construída com **ASP.NET Core 8.0**, a API segue os princípios de **Domain-Driven Design (DDD)** e **CQRS**, utilizando **Entity Framework Core** com **PostgreSQL** para persistência de dados e **IdentityServer4** para autenticação baseada em JWT.

## Funcionalidades

-   **Gerenciamento de Carros**: Criar, listar (por disponibilidade), atualizar, e deletar carros.
    
-   **Gerenciamento de Clientes**: Criar, listar, atualizar, e deletar clientes.
    
-   **Gerenciamento de Aluguéis**: Criar aluguéis, atualizar datas de início/fim/devolução.
    
-   **Autenticação**: Proteção de endpoints com tokens JWT via IdentityServer4.
    
-   **Validação**: Validação robusta de entrada com FluentValidation.
    
-   **Documentação**: Swagger para explorar e testar endpoints.

### Tecnologias Utilizadas

-   **.NET 8.0**: Framework principal.
    
-   **ASP.NET Core**: API REST.
    
-   **Entity Framework Core**: ORM para PostgreSQL.
    
-   **MediatR**: Implementação de CQRS.
    
-   **FluentValidation**: Validação de entrada.
    
-   **PostgreSQL**: Banco de dados relacional.
    
-   **IdentityServer4**: Autenticação JWT.
    
-   **Swagger**: Documentação interativa da API.
    
-   **Docker**: Contêiner para PostgreSQL.

## Pré-requisitos
    
-   **Docker**: Para rodar o PostgreSQL em contêiner (Instale o Docker).
    
-   **Git**: Para clonar o repositório.
    
-   **IdentityServer4**: Um servidor configurado em http://localhost:5001 (ou ajuste a URL no Program.cs).
    
-   **Ferramenta para cURL ou Postman**: Para testar endpoints.
## Configuração

### 1. Clonar o Repositório

```bash
git clone https://github.com/DevGEnacheC/Senff-Desafio.git
cd Senff-Desafio
```

### 2. Configurar o Banco de Dados (PostgreSQL)

Use Docker para iniciar um contêiner PostgreSQL:

```bash
docker-compose up -d
```

O docker-compose.yml configura um contêiner com:

-   Banco: AluguelCarrosDb
    
-   Usuário: postgres
    
-   Senha: pass
    
-   Porta: 5432
    

Verifique o contêiner:

```bash
docker ps
```

### 3. Restaurar Pacotes

Instale as dependências do projeto:

```bash
dotnet restore
```

### 4. Aplicar Migrações

Crie as tabelas no PostgreSQL:

```bash
dotnet ef migrations add InitialCreate --project AluguelCarros.Infrastructure --startup-project AluguelCarros.API
```

```bash
dotnet ef database update --project AluguelCarros.Infrastructure --startup-project AluguelCarros.API
```

### 5. Executar a Aplicação

Inicie a API:

```bash
dotnet run --project AluguelCarros.API
```

## Testes

### Tokens
Para poder testar a aplicação é necessário utilizar um token de autenticação, existem dois tipos de token: Cliente e Admin. Os comandos curl para conseguir os tokens estão logo abaixo:
#### Admin
```
curl -X POST http://localhost:5001/connect/token \
  -H "Content-Type: application/x-www-form-urlencoded" \
  -d "grant_type=client_credentials&client_id=admin&client_secret=admin_secret&scope=api.admin"
 ```
#### Cliente
```
curl -X POST http://localhost:5001/connect/token \
  -H "Content-Type: application/x-www-form-urlencoded" \
  -d "grant_type=client_credentials&client_id=cliente&client_secret=cliente_secret&scope=api.cliente"
 ```
Após executar os comandos copie o valor de **access_token**.

### Swagger
Com o projeto iniciado utilize a rota do [Swagger](http://localhost:5001/swagger/index.html) para testar os endpoints, para poder acessar as rotas é necessário um token, com o token em mãos, cole no **Authorize** do Swagger, pronto já é possivel testar todos os endpoints!