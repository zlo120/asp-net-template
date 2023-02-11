# asp-net-template
<i>This is for future reference for how to set up an ASP.NET project</i>

<h2>Command to enable EF Core in CLI:</h2>
<p>dotnet tool install --global dotnet-ef</p>

<h2>EF Core command to migrate:</h2>
<p>dotnet-ef migrations add MyMigration --context Context --project Infrastructure</p>

<h2>EF Core command to update database: </h2>
<p>dotnet-ef database update --context Context --project Infrastructure</p>
