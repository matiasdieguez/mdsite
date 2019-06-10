
## Add Migrations

- If entities are added or modified in Models, the corresponding migrations must be created following the steps of this point
- Verify the connection to the database on which you are working, which corresponds to the DefaultConnection setting in the API project in /ProjectName.Api/appsettings.json

- After making a set of changes on entities of the EF context, you must generate DB migration classes, using the following command, entering a name for the migration relative to the changes made, eg: "AddLanguageSupport"

- Positioning in the terminal or command line within the API project, eg:

`` `
cd /ProjectName.Api
dotnet ef migrations add AddLanguageSupport
`` `

- In the case of adding a relation that EF is creating as CASCADE ON DELETE, verify the migration file and modify the entity .OnDelete (DeleteBehavior.Cascade) method by .OnDelete (DeleteBehavior.Restrict)

## Database update

- Verify the connection to the database on which you are working, which corresponds to the DefaultConnection setting in the API project in /ProjectName.Api/appsettings.json

- The command below will impact the structure in the DB according to the existing migrations in the ProjectName.Api project

`` `
cd /ProjectName.Api
dotnet ef database update
`` `