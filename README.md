# PowerUtils.GuardClauses.Validations
Helpers, extensions and utilities to work with guard clauses

![Tests](https://github.com/TechNobre/PowerUtils.GuardClauses.Validations/actions/workflows/test-project.yml/badge.svg)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=TechNobre_PowerUtils.GuardClauses.Validations&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=TechNobre_PowerUtils.GuardClauses.Validations)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=TechNobre_PowerUtils.GuardClauses.Validations&metric=coverage)](https://sonarcloud.io/summary/new_code?id=TechNobre_PowerUtils.GuardClauses.Validations)

[![NuGet](https://img.shields.io/nuget/v/PowerUtils.GuardClauses.Validations.svg)](https://www.nuget.org/packages/PowerUtils.GuardClauses.Validations)
[![Nuget](https://img.shields.io/nuget/dt/PowerUtils.GuardClauses.Validations.svg)](https://www.nuget.org/packages/PowerUtils.GuardClauses.Validations)
[![License: MIT](https://img.shields.io/github/license/TechNobre/PowerUtils.GuardClauses.Validations.svg)](https://github.com/TechNobre/PowerUtils.GuardClauses.Validations/blob/main/LICENSE)



## Support to
- .NET 3.1
- .NET 5.0
- .NET 6.0



## Features

- [Exceptions](#Exceptions)
- [Guard clauses](#GuardClauses)


## Documentation

### Dependencies

- PowerUtils.Net.Primitives [NuGet](https://www.nuget.org/packages/PowerUtils.Net.Primitives/)
- PowerUtils.Validations.Primitives [NuGet](https://www.nuget.org/packages/PowerUtils.Validations.Primitives/)


### How to use

#### Install NuGet package <a name="Installation"></a>
This package is available through Nuget Packages: https://www.nuget.org/packages/PowerUtils.GuardClauses.Validations

**Nuget**
```bash
Install-Package PowerUtils.GuardClauses.Validations
```

**.NET CLI**
```
dotnet add package PowerUtils.GuardClauses.Validations
```



### Exceptions <a name="Exceptions"></a>

- `BadRequestException` (400):
  - `BadRequestException.Factory.Create(property, errorCode);`
  - `BadRequestException.Factory.CreateInvalid(property);`
  - `BadRequestException.Factory.CreateRequired(property);`
  - `BadRequestException.Throw(property, errorCode);`
  - `BadRequestException.ThrowInvalid(property);`
  - `BadRequestException.ThrowRequired(property);`
- `PropertyException` (400):
  - `PropertyException.Factory.Create(property, errorCode);`
  - `PropertyException.Factory.CreateInvalid(property);`
  - `PropertyException.Throw(property, errorCode);`
  - `PropertyException.ThrowInvalid(property);`
- `UnauthorizedException` (401):
  - `UnauthorizedException.Factory.Create(property);`
  - `UnauthorizedException.Factory.Create(property, errorCode);`
  - `UnauthorizedException.Throw(property);`
  - `UnauthorizedException.Throw(property, errorCode);`
- `ForbiddenException` (403):
  - `ForbiddenException.Factory.Create(property);`
  - `ForbiddenException.Factory.Create(property, errorCode);`
  - `ForbiddenException.Throw(property);`
  - `ForbiddenException.Throw(property, errorCode);`
- `NotFoundException` (404):
  - `NotFoundException.Factory.Create(property);`
  - `NotFoundException.Factory.Create(property, errorCode);`
  - `NotFoundException.Throw(property);`
  - `NotFoundException.Throw(property, errorCode);`
- `ConflictException` (409):
  - `ConflictException.Factory.Create(property);`
  - `ConflictException.Factory.Create(property, errorCode);`
  - `ConflictException.Throw(property);`
  - `ConflictException.Throw(property, errorCode);`


### Guard clauses <a name="GuardClauses"></a>

- __string:__
  - `Guard.Validate.IfNull()`;
  - `Guard.Validate.IfEmpty()`;
  - `Guard.Validate.IfNullOrEmpty()`;
  - `Guard.Validate.IfNullOrWhiteSpace()`;
  - `Guard.Validate.IfLongerThan()`;
  - `Guard.Validate.IfShorterThan()`;
  - `Guard.Validate.IfLengthOutOfRange()`;
  - `Guard.Validate.IfLengthEquals()`;
  - `Guard.Validate.IfLengthDifferent()`;
  - `Guard.Validate.IfEquals()`;
  - `Guard.Validate.IfDifferent()`;
  - `Guard.Validate.IfNotEmail()`;
- __short, ushort, int, uint, long, ulong, float, double, decimal:__
  - `Guard.Validate.IfGreaterThan()`;
  - `Guard.Validate.IfLessThan()`;
  - `Guard.Validate.IfEquals()`;
  - `Guard.Validate.IfDifferent()`;
- __DateTime:__
  - `Guard.Validate.IfGreaterThan()`;
  - `Guard.Validate.IfGreaterThanUtcNow()`;
  - `Guard.Validate.IfLessThan()`;
  - `Guard.Validate.IfLessThanUtcNow()`;
  - `Guard.Validate.IfEquals()`;
  - `Guard.Validate.IfDifferent()`;
  - `Guard.Validate.IfOutOfRange()`;
- __Guid:__
  - `Guard.Validate.IfEmpty()`;
  - `Guard.Validate.IfEquals()`;
  - `Guard.Validate.IfDifferent()`;
- __object:__
  - `Guard.Validate.IfNull()`;
- __IEnumerable:__
  - `Guard.Validate.IfNull()`;
  - `Guard.Validate.IfEmpty()`;
  - `Guard.Validate.IfNullOrEmpty()`;
  - `Guard.Validate.IfCountGreaterThan()`;
  - `Guard.Validate.IfCountLessThan()`;
- __Geolocation (float, double, decimal)__
  - `Guard.Validate.IfLatitudeOutOfRange()`;
  - `Guard.Validate.IfLongitudeOutOfRange()`;




## :warning: Warning
The methods `string.IfLengthZero`, `string.IfLengthDifferent`, `string.IfLengthGreaterThan`, `string.IfLengthLessThan`, `string.NotEmail` will be removed in 2021/05/31.




## Contribution

*Help me to help others*




## Credits

[Ardalis.GuardClauses](https://github.com/ardalis/GuardClauses) and [Throw](https://github.com/mantinband/throw) - They are excellent libraries used as inspiration to develop this library.




## LICENSE

[MIT](https://github.com/TechNobre/PowerUtils.GuardClauses.Validations/blob/main/LICENSE)




## Changelog

[Here](./CHANGELOG.md)
