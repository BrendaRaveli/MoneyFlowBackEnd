# 💰 MoneyFlow - API de Gestão Financeira

## 1. Objetivo
API robusta para controle financeiro pessoal, focada em boas práticas, arquitetura limpa e alta manutenibilidade.

## 2. Tecnologias Utilizadas
- **Backend**: .NET 8.0 & ASP.NET Core
- **Persistência**: Entity Framework Core & SQLite
- **Testes**: xUnit & Moq
- **Documentação**: Swagger/OpenAPI

## 3. Arquitetura
O projeto utiliza uma **Arquitetura em Camadas** com separação clara de responsabilidades:
- **Controllers**: Validação de entrada HTTP e roteamento.
- **Services**: Lógica de negócio e orquestração.
- **Repositories**: Acesso a dados e persistência.
- **Middlewares**: Tratamento global de exceções.
- **DTOs**: Contratos de entrada e saída (usando C# Records).

## 4. Funcionalidades
- CRUD completo de Categorias (Receitas/Despesas).
- Tratamento de erros centralizado (Global Exception Handling).
- Configuração de CORS para integração com Frontend.
- Cobertura de Testes Unitários na camada de Service.

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
```
Acesse `https://localhost:7173/swagger` para a documentação interativa.

## 7. Próximos Passos
- Implementar fluxo de Transações.
- Autenticação e Autorização (JWT).
- Integração final com Frontend Angular.

## 8. Aprendizados Consolidados
- **Injeção de Dependência**: Ciclo de vida Scoped.
- **Middleware**: Interceptação global de erros.
- **Testing**: Isolamento de dependências com Mocks.
- **REST**: Padronização de retornos (200, 201, 204, 404).
