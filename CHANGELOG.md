# [3.0.0](https://github.com/TechNobre/PowerUtils.GuardClauses.Validations/compare/v2.5.1...v3.0.0) (2022-11-19)


### Code Refactoring

* Removed deprecated methods ([d89fbb6](https://github.com/TechNobre/PowerUtils.GuardClauses.Validations/commit/d89fbb6903db16f2c135feaa6745dedea8b07948))
* Removed deprecated methods ([e74ffe7](https://github.com/TechNobre/PowerUtils.GuardClauses.Validations/commit/e74ffe7780b3a264acb5e0282e3e86febe6d6d3b))
* Removed deprecated methods ([e850bfc](https://github.com/TechNobre/PowerUtils.GuardClauses.Validations/commit/e850bfcbd5bfa1a3a518eb1bdd387b9601ebb2ea))
* Removed deprecated methods ([574e5e5](https://github.com/TechNobre/PowerUtils.GuardClauses.Validations/commit/574e5e591894153e9f151337d9b858b75e7ce517))
* Removed deprecated methods ([bdb04f8](https://github.com/TechNobre/PowerUtils.GuardClauses.Validations/commit/bdb04f85c40c9ce81ddb6b9b1baf58c524baed9b))


### Features

* Added new construction in exceptions to provide inner exceptions ([dce51ac](https://github.com/TechNobre/PowerUtils.GuardClauses.Validations/commit/dce51ac8d31bbf71dc4da1b7a6edac875a8536ab))


### BREAKING CHANGES

* Removed deprecated method `NotEmail`
* Removed deprecated method `IfLengthZero`
* Removed deprecated method `IfLengthDifference`
* Removed deprecated method `IfLengthLessThan`
* Removed deprecated method `IfLengthGreaterThan`

## [2.5.1](https://github.com/TechNobre/PowerUtils.GuardClauses.Validations/compare/v2.5.0...v2.5.1) (2022-07-24)


### Bug Fixes

* Release version ([42c1a14](https://github.com/TechNobre/PowerUtils.GuardClauses.Validations/commit/42c1a14755cd491debf06a9e131e4890cb626544))

# [2.5.0](https://github.com/TechNobre/PowerUtils.GuardClauses.Validations/compare/v2.4.0...v2.5.0) (2022-07-24)


### Features

* Add support to debug in runtime `Microsoft.SourceLink.GitHub` ([3b425c2](https://github.com/TechNobre/PowerUtils.GuardClauses.Validations/commit/3b425c2752e00d6324e1394ef8dbd4490d0bcbf5))

# [2.4.0](https://github.com/TechNobre/PowerUtils.GuardClauses.Validations/compare/v2.3.0...v2.4.0) (2022-04-08)


### Enhancements
* Removed `PowerUtils.Text` dependency;


### Features
* Added Guard `Guard.Validate.IfOutOfRange()` for dateTime;
* Added Guard `Guard.Validate.IfOutOfRange()` for numbers;




# [2.3.0](https://github.com/TechNobre/PowerUtils.GuardClauses.Validations/compare/v2.2.1...v2.3.0) (2022-04-05)


### Features
* Added Guard `Guard.Validate.IfLengthOutOfRange()`;




# [2.2.1](https://github.com/TechNobre/PowerUtils.GuardClauses.Validations/compare/v2.2.0...v2.2.1) (2022-04-04)


### Fixed
* Returned the same type as the input value for `Guard.Validate.IfNull()`;
* Added again the the specific `Guard.Validate.IfNull()` for strings;




# [2.2.0](https://github.com/TechNobre/PowerUtils.GuardClauses.Validations/compare/v2.1.0...v2.2.0) (2022-04-03)


### Enhancements
* Added the return of the value to be validated in all `Guard.Validate.*`;




# [2.1.0](https://github.com/TechNobre/PowerUtils.GuardClauses.Validations/compare/v2.0.0...v2.1.0) (2022-03-30)


### Features
* Added Guard `Guard.Validate.IfLatitudeOutOfRange()` and `Guard.Validate.IfLongitudeOutOfRange()`;




# [2.0.0](https://github.com/TechNobre/PowerUtils.GuardClauses.Validations/compare/v1.2.0...v2.0.0) (2022-03-26)


### Features
* Added Guard `Guard.Validate.IfNull()` for objects;
* Added Guard `Guard.Validate.IfEmpty()` for Enumerables;
* Added Guard `Guard.Validate.IfNullOrEmpty()` for Enumerables;
* Added Guard `Guard.Validate.IfNullOrEmpty()` for Enumerables;
* Added Guard `Guard.Validate.IfCountGreaterThan()` for Enumerables;
* Added Guard `Guard.Validate.IfCountLessThan()` for Enumerables;


### Updates
* Updated nuget dependencies;


### Breaking Changes
* Interface `IGuardClause` named to `IGuardValidationClause`;




# [1.2.0](https://github.com/TechNobre/PowerUtils.GuardClauses.Validations/compare/v1.1.0...v1.2.0) (2022-03-20)


### Features
* Added Guard `Guard.Validate.IfEquals()`;
* Added Guard `Guard.Validate.IfDifferent()`;


### Enhancements
* Discontinued the validation `string.IfLengthZero`, Can use the `string.IfEmpty` because it does the same validation;
* Discontinued the validation `string.IfLengthDifference`, Can use the `string.IfLengthDifferent` because the name is wrong;
* Discontinued the validation `string.IfLengthGreaterThan`, Can use the `string.IfLongerThan`. Improved method name;
* Discontinued the validation `string.IfLengthLessThan`, Can use the `string.IfShorterThan`. Improved method name;
* Discontinued the validation `string.NotEmail`, Can use the `string.IfNotEmail` because the name is wrong;




# [1.1.0](https://github.com/TechNobre/PowerUtils.GuardClauses.Validations/compare/v1.0.0...v1.1.0) (2022-03-16)


### Features
* Added Guard `Guard.Validate.IfEmpty(string)`;
* Added Guard `Guard.Validate.IfEmpty(guid)`;
* Added Guard `Guard.Validate.NotEmail(email)`;
* Added Guard `Guard.Validate.IfLengthEquals(value, length)`;
* Added Guard `Guard.Validate.IfLengthDifference(value, length)`;
* Added new constructor `UnauthorizedException(property, errorCode, message)`;
* Added new constructor `ForbiddenException(property, errorCode, message)`;
* Added new constructor `NotFoundException(property, errorCode, message)`;
* Added new constructor `ConflictException(property, errorCode, message)`;
* Added factory `BadRequestException.Factory.CreateRequired(property)`;
* Added factory `PropertyException.Factory.CreateRequired(property)`;
* Added factory `UnauthorizedException.Factory.Create(property, errorCode)`;
* Added factory `ForbiddenException.Factory.Create(property, errorCode)`;
* Added factory `NotFoundException.Factory.Create(property, errorCode)`;
* Added factory `ConflictException.Factory.Create(property, errorCode)`;
* Added Throw `BadRequestException.ThrowRequired(property)`;
* Added Throw `PropertyException.ThrowRequired(property)`;
* Added Throw `UnauthorizedException.Throw(property, errorCode)`;
* Added Throw `ForbiddenException.Throw(property, errorCode)`;
* Added Throw `NotFoundException.Throw(property, errorCode)`;
* Added Throw `ConflictException.Throw(property, errorCode)`;




# 1.0.0 (2022-03-15)

* Kickoff;
* Moved the attributes from [PowerUtils.Validations](https://github.com/TechNobre/PowerUtils.Validations) project to this one so it can be used individually;


### Features

* Added guard clauses;


### Breaking Changes

* `BaseValidationException.Notifications` named to `BaseValidationException.Errors` and the type changed from `IReadOnlyCollection<ValidationNotification>` to `IReadOnlyDictionary<string, string>`;
* Removed constructor `protected BaseValidationException(HttpStatusCode statusCode, string helpLink, SerializationInfo info, StreamingContext context)`;
* Exception `InvalidPropertyException` named to `PropertyException`;
* Removed constructor `public UnauthorizedException(string property, string errorCode)`;
* Removed constructor `public UnauthorizedException(string property, string errorCode, string message)`;
