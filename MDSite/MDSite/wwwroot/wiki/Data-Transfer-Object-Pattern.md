
## Data Transfer Object

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