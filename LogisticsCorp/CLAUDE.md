# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

LogisticsCorp is a logistics management system built with .NET 9.0, consisting of a REST API backend, Blazor Server frontend, and PostgreSQL database. The solution follows a clean architecture with four projects: API, Web, Data, and Shared.

## Build & Run Commands

### Building the Solution
```bash
# Build entire solution
dotnet build LogisticsCorp.sln

# Build specific project
dotnet build LogisticsCorp.API/LogisticsCorp.API.csproj
dotnet build LogisticsCorp.Web/LogisticsCorp.Web.csproj
```

### Running Projects Locally
```bash
# Run API (HTTP: 12301, HTTPS: 12501)
dotnet run --project LogisticsCorp.API/LogisticsCorp.API.csproj

# Run Web (HTTP: 12302, HTTPS: 12502)
dotnet run --project LogisticsCorp.Web/LogisticsCorp.Web.csproj
```

### Docker Compose
```bash
# Start all services (API, Web, PostgreSQL DB)
docker-compose up --build

# Stop services
docker-compose down

# Database will be available at localhost:15742
# API at localhost:12301 (HTTP) / 12501 (HTTPS)
# Web at localhost:12302 (HTTP) / 12502 (HTTPS)
```

### Database Migrations
```bash
# Add new migration (run from solution root)
dotnet ef migrations add <MigrationName> --project LogisticsCorp.Data

# Update database
dotnet ef database update --project LogisticsCorp.Data

# Rollback to specific migration
dotnet ef database update <MigrationName> --project LogisticsCorp.Data

# Remove last migration
dotnet ef migrations remove --project LogisticsCorp.Data
```

### Database Seeding
- Seeds run automatically on application startup via `app.MigrateDbAndSeedData()` in Program.cs
- Seed data files located in `LogisticsCorp.Data/Seeds/` (JSON format)
- Current seeders: RoleSeeder (order 1), UserSeeder (order 2)
- Default test user: jack.martin@example.com / P@ssw0rd

## Architecture & Project Structure

### Dependency Flow
```
LogisticsCorp.Web ──→ LogisticsCorp.Shared
                   ↘
                     LogisticsCorp.API ──→ LogisticsCorp.Data ──→ LogisticsCorp.Shared
```

### LogisticsCorp.API (Backend)
- **Purpose**: REST API with business logic and data operations
- **Key Services**:
  - `AuthService`: User authentication and credential validation (LogisticsCorp.API/Services/AuthService.cs)
  - `TokenService`: JWT token generation (LogisticsCorp.API/Services/TokenService.cs)
- **Patterns**:
  - Use `ApiResponseFactory.CreateResponse<T>(CustomResult<T>)` for all controller responses
  - Errors are centralized in `ErrorHandlingMiddleware`
  - All services registered via extension methods in `ServiceCollectionExtensions`

### LogisticsCorp.Data (Data Layer)
- **Database**: PostgreSQL with Entity Framework Core 9.0
- **DbContext**: `LogisticsCorpDbContext` extends `IdentityDbContext<User, IdentityRole<Guid>, Guid>`
- **Key Models**:
  - `User`: Identity user with 1:1 relationship to Employee OR Client
  - `Employee`: Staff with EmployeeType (Courier/OfficeStaff), Office assignment
  - `Client`: Customers with address and IsActive status
  - `Shipment`: Core business entity with sender/recipient, delivery tracking, status
  - `ShipmentHistory`: Audit trail for shipment status changes
  - `Office`: Company locations
  - `PricingRule`: Weight-based pricing for deliveries
- **Audit Pattern**: Entities implementing `IAuditedEntity` get automatic CreatedOn/ModifiedOn timestamps in `SaveChangesAsync()`
- **Relationships**: All foreign keys use `DeleteBehavior.Restrict` for data integrity

### LogisticsCorp.Web (Frontend)
- **Framework**: Blazor Server with MudBlazor 8.6.0 (Material Design components)
- **Base Component**: Extend `ExtendedComponentBase` for reusable component functionality (navigation, notifications, local storage, etc.)
- **Key Services**:
  - `HttpClientService`: Creates API clients with Bearer token injection
  - `UserStateContainer`: Scoped service storing current user info (Id, Email, FullName, Roles)
  - `LoaderService`: Manages global loading state
- **Authentication**: Token stored in ProtectedLocalStorage, injected into API calls via HttpClientService

### LogisticsCorp.Shared (Cross-cutting)
- **CustomResult Pattern**: Standard response wrapper for API operations
  - Success: `new CustomResult<T>(value)`
  - Error: `new CustomResult<T>(new ErrorResult(message, errorCode))`
  - Check: `if (result.Succeeded) { var value = ((CustomResult<T>)result).Value; }`
- **Error Codes**: Format `CATEGORY_NUMBER_HTTPSTATUS` (e.g., "LOGIN_120_403", "DB_100_400")
  - HTTP status extracted from last 3 digits
  - See `ErrorCodes` class for predefined codes
- **Database Error Mapping**: PostgreSQL-specific error mapping in `Utils.MapPostgresException()`
  - Unique violations → DB_UNIQUE_VIOLATION with custom messages from `IndexConstants`
  - Foreign key violations → DB_FOREIGN_KEY_VIOLATION
  - NULL violations → DB_NOT_NULL_VIOLATION

## Key Conventions

### API Controllers
- Use `[Authorize]` attribute for protected endpoints
- Return `ApiResponseFactory.CreateResponse<T>(result)` or `AdaptAndCreateResponse<TSource, TDest>(result)`
- Error codes automatically map to HTTP status codes

### Adding New Entities
1. Create model in `LogisticsCorp.Data/Models/`
2. Implement `IAuditedEntity` for automatic timestamps
3. Add `DbSet<T>` to `LogisticsCorpDbContext`
4. Configure relationships in `OnModelCreating()` or `ModelBuilderExtensions`
5. Run migration: `dotnet ef migrations add Add<EntityName> --project LogisticsCorp.Data`
6. Update database: `dotnet ef database update --project LogisticsCorp.Data`

### Adding New Seeders
1. Create seeder class in `LogisticsCorp.Data/Seeders/` implementing `ISeeder`
2. Set execution order via `Order` property (lower numbers run first)
3. Add seed data JSON in `LogisticsCorp.Data/Seeds/`
4. Register in `ServiceCollectionExtensions.AddSeeders()`

### Blazor Components
- Extend `ExtendedComponentBase` for access to common services
- Use `@inject` for additional dependencies
- Access user info via `UserStateContainer`
- Show notifications with `Notify()` method
- Control loading state with `LoaderService`

### Authentication
- JWT tokens configured in appsettings.json under `JwtSettings`
- Claims: USER_ID, FULL_NAME, EMAIL, ROLE (see `Constants.Claims`)
- Token expiration configurable via `AccessTokenExpirationMinutes`
- User must have `IsActive = true` to authenticate

## Configuration Files

### appsettings.json (API & Web)
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=logisticscorp.db;Username=postgres;Password=postgres;Database=LogisticsCorp"
  },
  "ApiAddress": "http://logisticscorp.api/",
  "JwtSettings": {
    "SecurityKey": "your-secret-key",
    "AccessTokenExpirationMinutes": 60,
    "RefreshTokenExpirationDays": 7
  }
}
```

### Global Usings
- Each project has `GlobalUsings.cs` with commonly used namespaces
- Mapster imported globally for object mapping
- Entity Framework, Identity, and project references available without explicit imports

## Important Notes

- **Nullable Reference Types**: Enabled across all projects (`<Nullable>enable</Nullable>`)
- **Delete Behavior**: All foreign keys use `DeleteBehavior.Restrict` to prevent accidental cascading deletes
- **Unique Constraints**: User can only be linked to ONE Employee OR ONE Client (enforced by DB)
- **Role Enforcement**: Each user can have only one role (unique index on AspNetUserRoles.UserId)
- **Validation**: Email and phone validation regex patterns in `ValidationConstants`
- **Main Branch**: `main` (use for PRs)
- **Current Branch**: `Seeders`
- When having to add new namespaces, in the cases where the namespace is more niche and will be used only once or twice - set a "using" directive at the top of the class, otherwise add it to that project's GlobalUsings