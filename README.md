# asp-net-template
<h1>For future reference of how I should formate an ASP.NET API</h1>

<h2>Command to enable EF Core in CLI:</h2>
<p>dotnet tool install --global dotnet-ef</p>

<h2>EF Core command to migrate:</h2>
<p>dotnet-ef migrations add MyMigration --context Context --project Infrastructure</p>

<h2>EF Core command to update database: </h2>
<p>dotnet-ef database update --context Context --project Infrastructure</p>
