## Fluent Validation

- Validations will be executed on the properties of the DTO objects, which are the ones that communicate data between the Frontend (App) and the Backend (Api)

- They must be invoked both from the API controllers and the App controllers, to perform the validation in Frontend and Backend

- The name of the class must have the suffix Validations

- FluentValidations.AspNetCore is used, whose NuGet package is already added as a reference in the Api and App projects

- Documentation [https://fluentvalidation.net/aspnet](https://fluentvalidation.net/aspnet)

> ProjectName.Dto/Validations

```csharp
using System;
using System.Linq;
using FluentValidation;
using ProjectName.Dto;
using ProjectName.Localization;

namespace ProjectName.Dto.Validations
{

public class UserValidation : AbstractValidator<UserDto>
{
 public UserValidation()
 {
  RuleFor(item => item.Username)
     .NotEmpty()
     .WithMessage(Localizer.Get(Resources.Required));
 }

}
}
```
