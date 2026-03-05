# Students Management API

API REST para gerenciamento de alunos, desenvolvida com **ASP.NET Core** seguindo a arquitetura **Ports and Adapters (Hexagonal)**.

---

## Arquitetura

```
Business/ (Domain)
├── Entities/          → Entidades de domínio (Student, Course, Subject)
├── Exceptions/        → Exceções de domínio (DomainException, NotFoundException, BadRequestException)
├── Interfaces/        → Portas (IBaseRepository, IStudentRepository, IBaseService, IStudentService, ...)
└── Services/          → Lógica de negócio (BaseService, StudentService, CourseService, SubjectService)

Infraestructure/ (Adapters de Saída)
├── DbContext.cs       → Configuração do EF Core (MySQL)
└── Repositories/      → BaseRepository, StudentRepository, CourseRepository, SubjectRepository

Api/ (Adapters de Entrada)
├── Controllers/       → StudentsController, CoursesController, SubjectsController
├── DTOs/              → Requests e Responses para cada entidade
├── Mappers/           → Conversão entre DTO e entidade de domínio
├── Validators/        → Validações com FluentValidation
└── Middlewares/       → ExceptionHandlingMiddleware
```

### Princípios aplicados

- **Desacoplamento estrito**: a camada `Business` não referencia nenhuma outra camada
- **Inversão de dependência**: Services e Controllers dependem apenas de interfaces (portas)
- **Fluxo**: `Controller → Service (interface) → Repository (interface) → Banco`
- **DTOs**: a entidade de domínio nunca é exposta diretamente ao cliente

---

## Tecnologias

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core 9 + Pomelo (MySQL)
- FluentValidation
- Swagger / Swashbuckle

---

## Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- MySQL rodando localmente

---

## Configuração

Edite a connection string em `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost; port=3306; database=students_management_db; user=SEU_USER; password=SUA_SENHA;"
}
```

---

## Rodando o projeto

```bash
# Restaurar dependências
dotnet restore

# Criar o banco de dados via migrations
dotnet ef migrations add InitialCreate
dotnet ef database update

# Executar a API
dotnet run
```

Acesse o Swagger em: `http://localhost:5000/swagger`

---

## Endpoints

### Students

| Método | Rota | Descrição |
|--------|------|-----------|
| GET | `/api/students` | Lista todos os alunos |
| GET | `/api/students/{id}` | Busca aluno por ID |
| POST | `/api/students` | Matricula novo aluno |
| PATCH | `/api/students/{id}/name` | Atualiza nome do aluno |
| PATCH | `/api/students/{id}/email` | Atualiza email do aluno |
| PATCH | `/api/students/{id}/transfer` | Transfere aluno de curso |
| DELETE | `/api/students/{id}` | Remove aluno |

### Courses

| Método | Rota | Descrição |
|--------|------|-----------|
| GET | `/api/courses` | Lista todos os cursos |
| GET | `/api/courses/{id}` | Busca curso por ID |
| POST | `/api/courses` | Cria novo curso |
| DELETE | `/api/courses/{id}` | Remove curso |

### Subjects

| Método | Rota | Descrição |
|--------|------|-----------|
| GET | `/api/subjects` | Lista todas as matérias |
| GET | `/api/subjects/{id}` | Busca matéria por ID |
| POST | `/api/subjects` | Cria nova matéria |
| DELETE | `/api/subjects/{id}` | Remove matéria |

---

## Regras de Negócio (Matrícula)

Implementadas manualmente no método `StudentService.Enroll`:

- **Presença**: `FirstName` não pode ser nulo ou vazio
- **Extensão**: `FirstName` deve ter no máximo 50 caracteres
- **Domínio**: o e-mail deve terminar com `@faculdade.edu`
- **Unicidade**: o e-mail não pode pertencer a outro aluno já cadastrado

---

## Exemplo de requisição (POST /api/students)

```json
{
  "firstName": "João",
  "lastName": "Silva",
  "email": "joao@faculdade.edu",
  "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}
```
