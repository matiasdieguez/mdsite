
# Data Transfer Object

This pattern is used to pass information decoupling the data objects from the Domain Model Entities

- Use this pattern to avoid exposing Model Entities wich contains sensitive or non relevant data
- It's better to create an object with only the required fields to send over the layers of the app
- This pattern is also used to make ligth flat objects, witout blobs or many fields that are attached to the original Entity

## Example
If you have to design an API endpoint to get a list of users and emails, you must add an operation "api/user/list" 
that returns a List<UserDto> 

you have this Entity

```csharp
public class User 
{
	public int Id { get; set; }
	public string Username { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
	public byte[] Photo { get; set; }
}
```

And this is the corresponding DTO

```csharp
public class UserDto
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Email { get; set; }
}
```

 ## Map the Entity to a DTO 
 
- You can use a LINQ Select projection to fill the DTO from a EntityFramework's DbContext query

```csharp
var userDtoList = context.Users.Select(u=> 
new UserDto { Id = u.Id, 
              Name = string.Format("{0},{1}", u.LastName, u.FirstName), 
              Email = u.Email }).ToList();
```

- You can use AutoMapper or similar libraries but you must take care of mappings definitions, complete lifecycle and reutilization. It's better to keep it simple with LINQ.

 ## Add Read Only properties
 
- You can add read only properties to perform operations between other fields, calculations, etc..

For example, the DisplayName property in the following DTO

```csharp
public class UserDto
{
	public int Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string DisplayName { get { return string.Format("{0},{1}", LastName, FirstName); } }
	public string Email { get; set; }
}
```
## Recommendations

- The name must be in the singular
- It must be in PascalCase
- Must have the suffix Dto at the end of the name
- The fields must be represented as public properties
- If certain DTOs have a complex structure, try to simplify them, generate new DTOs, avoid generating loops of entities (one within another) and try to limit the transport of very heavy objects such as collections that have many items
- If a modification requires altering a DTO that is used in several service operations, create a new DTO that reflects the functionality and leave the previous one unchanged to maintain compatibility, especially if an existing property is deleted or modified, if you are not going to refactor all related operations