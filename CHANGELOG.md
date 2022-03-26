# Changelog




## [2.0.0] - 2022-03-26
[Full Changelog](https://github.com/TechNobre/PowerUtils.GuardClauses.Validations/compare/v1.2.0...v2.0.0)


### Updates
- Updated nuget dependencies;


### Breaking Changes
- Interface `IGuardClause` named to `IGuardValidationClause`;




## [1.2.0] - 2022-03-20
[Full Changelog](https://github.com/TechNobre/PowerUtils.GuardClauses.Validations/compare/v1.1.0...v1.2.0)


### New Features
- Added Guard `Guard.Validate.IfEquals()`;
- Added Guard `Guard.Validate.IfDifferent()`;


### Enhancements
- Discontinued the validation `string.IfLengthZero`, Can use the `string.IfEmpty` because it does the same validation;
- Discontinued the validation `string.IfLengthDifference`, Can use the `string.IfLengthDifferent` because the name is wrong;
- Discontinued the validation `string.IfLengthGreaterThan`, Can use the `string.IfLongerThan`. Improved method name;
- Discontinued the validation `string.IfLengthLessThan`, Can use the `string.IfShorterThan`. Improved method name;
- Discontinued the validation `string.NotEmail`, Can use the `string.IfNotEmail` because the name is wrong;




## [1.1.0] - 2022-03-16
[Full Changelog](https://github.com/TechNobre/PowerUtils.GuardClauses.Validations/compare/v1.0.0...v1.1.0)


### New Features
- Added Guard `Guard.Validate.IfEmpty(string)`;
- Added Guard `Guard.Validate.IfEmpty(guid)`;
- Added Guard `Guard.Validate.NotEmail(email)`;
- Added Guard `Guard.Validate.IfLengthEquals(value, length)`;
- Added Guard `Guard.Validate.IfLengthDifference(value, length)`;
- Added new constructor `UnauthorizedException(property, errorCode, message)`;
- Added new constructor `ForbiddenException(property, errorCode, message)`;
- Added new constructor `NotFoundException(property, errorCode, message)`;
- Added new constructor `ConflictException(property, errorCode, message)`;
- Added factory `BadRequestException.Factory.CreateRequired(property)`;
- Added factory `PropertyException.Factory.CreateRequired(property)`;
- Added factory `UnauthorizedException.Factory.Create(property, errorCode)`;
- Added factory `ForbiddenException.Factory.Create(property, errorCode)`;
- Added factory `NotFoundException.Factory.Create(property, errorCode)`;
- Added factory `ConflictException.Factory.Create(property, errorCode)`;
- Added Throw `BadRequestException.ThrowRequired(property)`;
- Added Throw `PropertyException.ThrowRequired(property)`;
- Added Throw `UnauthorizedException.Throw(property, errorCode)`;
- Added Throw `ForbiddenException.Throw(property, errorCode)`;
- Added Throw `NotFoundException.Throw(property, errorCode)`;
- Added Throw `ConflictException.Throw(property, errorCode)`;




## [1.0.0] - 2022-03-15

- Kickoff;
- Moved the attributes from [PowerUtils.Validations](https://github.com/TechNobre/PowerUtils.Validations) project to this one so it can be used individually;


### New Features

- Added guard clauses;


### Breaking Changes

- `BaseValidationException.Notifications` named to `BaseValidationException.Errors` and the type changed from `IReadOnlyCollection<ValidationNotification>` to `IReadOnlyDictionary<string, string>`;
- Removed constructor `protected BaseValidationException(HttpStatusCode statusCode, string helpLink, SerializationInfo info, StreamingContext context)`;
- Exception `InvalidPropertyException` named to `PropertyException`;
- Removed constructor `public UnauthorizedException(string property, string errorCode)`;
- Removed constructor `public UnauthorizedException(string property, string errorCode, string message)`;