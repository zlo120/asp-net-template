# asp-net-template
For future reference of how I should formate an ASP.NET API

<h1>Command to enable EF Core in CLI:<h1>
dotnet tool install --global dotnet-ef

<h1>EF Core command to migrate:<h1>
dotnet-ef migrations add MyMigration --context Context --project Infrastructure

<h1>EF Core command to update database: <h1>
dotnet-ef database update --context Context --project Infrastructure