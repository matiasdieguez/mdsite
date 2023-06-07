
## Entity Creation

The entity represents a table or data set with certain properties or fields

- Entities will be part of the EntityFramework context, whose NuGet package is added as a reference to the Api project
- Documentation https://docs.microsoft.com/en-us/ef/core/modeling/
- The name of the class must be in English
- It must be in the singular
- It must be in PascalCase
- The fields must be represented as public properties
- Use the EF configuration through Attributes

Establish a property as mandatory
```csharp
[Required]
public string Name {get; set; }
```

Set a string property with a maximum of characters
```csharp
[MaxLength (200)]
public string Name {get; set; }
```
### Simple entity example

Creating a single-level entity without relationships

- By EF convention, the properties named Id will be generated as a PrimaryKey with 1-in-1 Autonumber Identity

In the API project, within the Models / Entities folder add the .cs file for the class c # that represents the entity, eg:

 > /ProjectName.Api/Model/Entities/Language.cs

```csharp
using using System.ComponentModel.DataAnnotations;

namespace ProjectName.Api.Models.Entities
{
    public class Language
    {
        public int Id {get; set; }

        [Required]
        [MaxLength (200)]
        public string Name {get; set; }

        [Required]
        public bool Active {get; set;}
    }
}
```

### Adding Entity to Context of EntityFramework

Edit the class that inherits from DbContext that is in /ProjectName.Api/Model/Context and add the corresponding DbSet <> with the name of the plural property and define it as a public component, ex .:

> /ProjectName.Api/Model/Context/ProjectNameDbContext.cs

```csharp
    // previous code omitted
    public class ProjectNameDbContext: DbContext
    {
        public DbSet <Language> Languages ​​{get; set; }
    // remaining code omitted
```

### Example of Entity with Relations 1 to N

 This example shows the creation of the Country and Province entities, where 1 Country can have N Provinces, therefore the Province entity will have 1 Country assigned.

To make this configuration, a property with the id of the relation (ex .: CountryId in Province) and another with the object of the entity of the relation (ex .: Country in Province) marked with the attribute must be created in the dependent entity. [ForeignKey], which should receive as parameter the name of the relationship id property (ex .: [ForeignKey ("CountryId")])

> ProjectName.Api / Models / Entities / Country.cs
```cshsarp
using System.ComponentModel.DataAnnotations;

namespace ProjectName.Api.Model.Entities
{
    public class Country
    {
        public int Id {get; set; }

        [Required]
        [MaxLength (200)]
        public string Name {get; set; }
    }
}
```

> ProjectName.Api / Models / Entities / Province.cs
```csharp
using using System.ComponentModel.DataAnnotations;

namespace ProjectName.Api.Model.Entities
{
    public class Province
    {
        public int Id {get; set; }

        [Required]
        [MaxLength (200)]
        public string Name {get; set; }

        [Required]
        public int CountryId {get; set; }

        [ForeignKey ("CountryId")]
        public virtual Country Country {get; set; }
    }
}
```

### Example of Entity with N to N Relationships

This example shows the relationship of the entities User and Permissions, where N Users can have N Permissions, therefore there must be a table of many-to-many relationship

To perform this configuration, EF FluentApi must be used in the OnModelCreating override

```csharp
// previous code omitted
protected override void OnModelCreating (ModelBuilder modelBuilder)
{

    modelBuilder.Entity <User> (). HasMany (x => x.Permissions) .WithMany (). Map (c =>
    {
        c.MapLeftKey ("UserId");
        c.MapRightKey ("PermissionId");
        c.ToTable ("UserPermissions", "dbo");
    });
// remaining code omitted
```
### Example of Entity with Index

Adding an index
```csharp
// previous code omitted
protected override void OnModelCreating (ModelBuilder modelBuilder)
{

    modelBuilder.Entity <User> ()
    .HasIndex (u => u.Username);
// remaining code omitted
```

Added a unique index
```csharp
// previous code omitted
protected override void OnModelCreating (ModelBuilder modelBuilder)
{

    modelBuilder.Entity <User> ()
    .HasIndex (u => u.Username)
    .IsUnique ();
// remaining code omitted
```

### Example of Entity with Inheritance

EF supports inheritance between entities, automatically creating the structure and relating objects to the parent class

```csharp

public class Credit
{
    public int Id {get; set; }
    public int ClientId {get; set; }
    public DateTime CreationDate {get; set; }
    public double Ammount {get; set; }
    public double Rate {get; set; }
}

public class PersonalCredit: Credit
{
     public SalaryRecipt ClientSalaryRecipt {get; set; }
}

public class PrendaryCredit: Credit
{
     public Guarantee ClientGuarantee {get; set; }
}
```