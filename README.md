# asp-net-template
For future reference of how I should formate an ASP.NET API

Command to enable EF Core in CLI:
dotnet tool install --global dotnet-ef

EF Core command to migrate:
dotnet-ef migrations add MyMigration --context Context --project Infrastructure

EF Core command to update database: 
dotnet-ef database update --context Context --project Infrastructure