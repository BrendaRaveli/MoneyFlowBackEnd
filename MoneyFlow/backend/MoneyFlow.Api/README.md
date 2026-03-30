# 💰 MoneyFlow - Sistema de Gestão Financeira

## 🎯 1. Objetivo
O **MoneyFlow** é um sistema de controle financeiro pessoal desenvolvido para ajudar no rastreamento de despesas e receitas de forma organizada. O foco principal deste projeto é servir como uma base técnica sólida em .NET, priorizando a clareza do código e a separação de responsabilidades.

## 🚀 2. Tecnologias Utilizadas
- **.NET 8.0**: Plataforma principal para o desenvolvimento da Web API.
- **Entity Framework Core**: ORM (Object-Relational Mapper) para comunicação com o banco de dados.
- **SQLite**: Banco de dados leve e portátil (armazenado em arquivo).
- **Swagger/OpenAPI**: Ferramenta para documentação e teste dos endpoints da API.

## 🏛️ 3. Arquitetura
O projeto segue uma **Arquitetura em Camadas** simples, o que facilita o aprendizado e a manutenção do sistema:

- **Controllers**: Porta de entrada da API. Recebe as requisições HTTP e envia as respostas.
- **Services**: Camada de lógica de negócio. Transforma dados entre Entidades e DTOs.
- **Repositories**: Responsável exclusivo pelo acesso ao banco de dados (leitura e escrita).
- **Dtos (Data Transfer Objects)**: Objetos que definem quais dados entram e saem da API, protegendo a estrutura interna.
- **Entities**: Representação fiel das tabelas do banco de dados no código C#.
- **Data (DbContext)**: O "coração" da integração com o banco de dados via EF Core.

## ✅ 4. Funcionalidades Atuais
- **Gestão de Categorias**:
  - Cadastro de novas categorias (ex: Alimentação, Lazer, Salário).
  - Listagem de todas as categorias.
  - Consulta de categoria por ID.
  - Atualização de dados da categoria.
  - Exclusão de categorias.

## 🔗 5. Endpoints Principais
| Método | Endpoint | Descrição |
| :--- | :--- | :--- |
| **GET** | `/api/category` | Lista todas as categorias |
| **GET** | `/api/category/{id}` | Busca uma categoria pelo ID |
| **POST** | `/api/category` | Cria uma nova categoria |
| **PUT** | `/api/category/{id}` | Atualiza uma categoria existente |
| **DELETE** | `/api/category/{id}` | Remove uma categoria |

## 🛠️ 6. Como rodar o projeto
1. **Pré-requisitos**: Ter o SDK do .NET 8 instalado.
2. **Clonar o repositório**: `git clone <url-do-repositorio>`
3. **Restaurar dependências**: No terminal, execute `dotnet restore`.
4. **Atualizar Banco de Dados**: Execute `dotnet ef database update` para criar o banco SQLite local.
5. **Executar**: Execute `dotnet run --project MoneyFlow.Api`.
6. **Testar**: Acesse `https://localhost:<porta>/swagger` para ver a documentação interativa.

## 🔜 7. Próximos Passos
- Implementar o fluxo de **Transações** (Receitas e Despesas).
- Adicionar validações de dados (ex: nome da categoria obrigatório).
- Criar filtros por tipo de categoria (Receita/Despesa).
- Integrar com um frontend em Angular.

## 💡 8. Aprendizados
Durante o desenvolvimento desta etapa, foram consolidados conhecimentos em:
- **Injeção de Dependência**: Como registrar e consumir serviços de forma desacoplada.
- **Migrations**: O processo de versionamento de banco de dados por meio do código.
- **CRUD Assíncrono**: Uso de `async/await` para operações de I/O eficientes.
- **Separação de Camadas**: A importância de cada componente ter uma única responsabilidade no sistema.
