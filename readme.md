## Технологический стек
- .NET 9.0
- ASP.NET Core Web API
- Entity Framework Core 9.0
- PostgreSQL
- MediatR (CQRS)
- AutoMapper
- ASP.NET Core Identity
- JWT Authentication

## Архитектура проекта

### Текущая структура слоев:
- **Api** - Presentation слой (контроллеры, middleware)
- **Application** - Application слой (CQRS handlers, DTOs, бизнес-логика)
- **Domain** - Domain слой (сущности, value objects, доменные исключения)
- **Infrastructure** - Infrastructure слой (DbContext, миграции, конфигурации EF)
- **Shared** - Общие интерфейсы CQRS

## Как запустить проект

### Предварительные требования
- .NET 9.0 SDK
- PostgreSQL
- IDE (Visual Studio 2022 / JetBrains Rider / VS Code)

### Настройка базы данных
Обновить строку подключения в `Api/appsettings.json`:
```json
"ConnectionStrings": {
  "PostgresConnection": "Host=localhost;Port=5432;Database=cqrs;Username=postgres;Password=your_password"
}
```

### Запуск
```bash
cd Api
dotnet restore
dotnet ef database update
dotnet run
```

## API Endpoints

### Topics
- `GET /api/topics` - Получить все топики
- `GET /api/topics/{id}` - Получить топик по ID
- `POST /api/topics` - Создать топик
- `PUT /api/topics/{id}` - Обновить топик
- `DELETE /api/topics/{id}` - Удалить топик (soft delete)

### Authentication
- `POST /api/auth/login` - Авторизация
- `POST /api/auth/register` - Регистрация

### AspNetUsers
- Стандартные таблицы ASP.NET Core Identity
- Дополнительные поля: FullName, About

### Безопасность
- JWT токены с коротким временем жизни (15 минут)
- HMAC SHA512 подпись
- CORS настроен для React приложения на localhost:3000
- Все endpoints защищены аутентификацией (кроме /api/auth/*)
