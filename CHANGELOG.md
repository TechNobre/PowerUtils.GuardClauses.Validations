# Changelog




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