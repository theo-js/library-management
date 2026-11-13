param(
    [Parameter(Mandatory=$true)]
    [string]$Name
)

dotnet ef migrations add $Name `
    --project ./src/Library.Infrastructure/Library.Infrastructure.csproj `
    --startup-project ./src/Library.Http/Library.Http.csproj `
    --output-dir Persistence/Migrations