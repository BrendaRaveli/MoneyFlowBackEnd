```markdown
# GEMINI.md — MoneyFlow backend
# 💰 MoneyFlow - API de Gestão Financeira

> 🚧 **Estado do Projeto: Em Desenvolvimento (Work in Progress)** 🚧

> *Esta API está sendo construída e aprimorada gradativamente.*

## 1. Objetivo
API robusta para controle financeiro pessoal, focada em boas práticas, arquitetura limpa e alta manutenibilidade.

## 2. Tecnologias Utilizadas
- **Backend**: .NET 8.0 & ASP.NET Core
- **Persistência**: Entity Framework Core & SQLite
- **Testes**: xUnit & Moq
- **Documentação**: Swagger/OpenAPI

## 3. Arquitetura e Padrões
O projeto utiliza uma **Arquitetura em Camadas** com separação clara de responsabilidades:
- **Controllers**: Validação de entrada HTTP e roteamento (sem regras de negócio).
- **Services (Service Layer)**: Lógica de negócio e orquestração.
- **Repositories (Repository Pattern)**: Abstração do acesso a dados e persistência via EF Core.
- **Middlewares**: Tratamento global de exceções (Global Exception Handling).
- **DTOs**: Contratos de entrada e saída, evitando exposição direta das entidades do banco.

## 4. Funcionalidades Atuais
- CRUD completo de Categorias (Receitas/Despesas).
- Tratamento de erros centralizado padronizado.
- Configuração de CORS para integração com o Frontend Angular.
- Cobertura de Testes Unitários isolados na camada de Service.

## 5. Endpoints Principais (`/api/categories`)
| Método | Endpoint | Descrição |
| :--- | :--- | :--- |
| **GET** | `/api/categories` | Lista todas as categorias |
| **GET** | `/api/categories/{id}` | Busca categoria por ID |
| **POST** | `/api/categories` | Cria nova categoria |
| **PUT** | `/api/categories/{id}` | Atualiza categoria existente |
| **DELETE** | `/api/categories/{id}` | Remove categoria |

## 6. Como rodar o projeto
```bash
# 1. Atualizar banco de dados
dotnet ef database update --project MoneyFlow.Api

# 2. Rodar testes unitários
dotnet test

# 3. Executar a API
dotnet run --project MoneyFlow.Api