
## Technologien

* [ASP.NET Core 6](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-6.0)
* [Entity Framework Core 6](https://docs.microsoft.com/en-us/ef/core/)
* [Nuxt 3](https://nuxtjs.org/)
* [MediatR](https://github.com/jbogard/MediatR)
* [AutoMapper](https://automapper.org/)
* [FluentValidation](https://fluentvalidation.net/)
* [NUnit](https://nunit.org/), [FluentAssertions](https://fluentassertions.com/), [Moq](https://github.com/moq) & [Respawn](https://github.com/jbogard/Respawn)

### Datenbank Konfiguration

Aktuell funktioniert OpenExam ausschließlich mit PostgreSQL, grundsätzlich sollen aber weitere Datenbanken wie
sqlite und MySQL/MariaDB ebenfalls angeboten werden.

Das docker-compose Skript erstellt alles Nötige um OpenExam zu nutzen

### Datenbank Migrationen

`dotnet-ef` erstellt weitere Migrationen

* `--project src/Infrastructure` (optional if in this folder)
* `--startup-project src/WebUI`
* `--output-dir Persistence/Migrations`

Aus dem Root-Verzeichnis:

 `dotnet ef migrations add "SampleMigration" --project src\Infrastructure --startup-project src\WebUI --output-dir Persistence\Migrations`
