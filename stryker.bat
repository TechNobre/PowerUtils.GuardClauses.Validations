dotnet tool restore
dotnet restore
dotnet build --no-restore
dotnet stryker -tp tests/PowerUtils.GuardClauses.Validations.Tests/PowerUtils.GuardClauses.Validations.Tests.csproj --reporter cleartext --reporter html -o