# .NET C# Junior Developer Roadmap

##  Conceptos básicos C# y .NET
- Introduccion al lenguaje C# https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/
- Videos introductorios http://dot.net/videos
- Curso de Microsoft Virtual Academy https://mva.microsoft.com/en-US/training-courses/c-fundamentals-for-absolute-beginners-16169

## ASP.NET 
- Aprender sobre la forma de trabajo de .NET utilizando el framework ASP.NET Core en las distintas capas para completar el desarrollo Full-Stack de un proyecto

	### Crear la solucion
	- Comandos básicos de .NET Core https://matiasdieguez.com/DocsPage?path=DotNet%20Core%20Quickstart.md
	- Arquitectura de la solución que generaremos https://matiasdieguez.com/DocsPage?path=DotNet%20Core%20Sample%20Solution%20Architecture.md
	- Código completo de esta solución de ejemplo disponible en https://github.com/matiasdieguez/samplesolution

	### Capa de Persistencia (Acceso a Datos)
	Las clases de esta capa vinculan los objetos .NET a estructuras en la base de datos, utilizando EntityFramework (EF)
	- Paso a paso definicion uso de Entity Framework https://matiasdieguez.com/DocsPage?path=EntityFramework%20Entity%20Definition.md
	- Documentación de .NET https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/new-db?tabs=netcore-cli
	- Código de ejemplo https://github.com/aspnet/Docs/tree/master/aspnetcore/data/ef-mvc/intro/samples/cu-final

	### Capa de API REST (Servicios Web)
	Las clases de esta capa exponen como un servicio web REST las operaciones del servidor (Backend) de la aplicación
	- Paso a paso creacion de servicios REST con WEB API https://matiasdieguez.com/DocsPage?path=WebApi%20Endpoints%20Creation.md
	- Creacion de Data Transfer Objects https://matiasdieguez.com/DocsPage?path=Data%20Transfer%20Object%20Pattern.md
	- Documentación de .NET https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-vsc?view=aspnetcore-2.1

	### Capa de Presentación
	Esta capa accede al servicio REST del Backend y muestra una interfaz de usuario (UI) utilizando el patrón Model-View-Controller (MVC)
	- Paso a paso creación de cliente de servicio REST https://matiasdieguez.com/DocsPage?path=WebApi%20Client.md
	- https://matiasdieguez.com/DocsPage?path=MVC%20Controllers.md
	- https://matiasdieguez.com/DocsPage?path=MVC%20Views.md
	- Documentación de .NET https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-3.0&tabs=visual-studio-code

## Portfolio
- Crear o acceder una cuenta personal en GitHub 
- Crear un repositorio en GitHub para alojar tu proyecto portfolio 

## Primer Proyecto
- Crear el codigo para cada capa del proyecto MyEvents y hacer el push al repositorio

	### Capa de Persistencia
	Crear el acceso a datos para guardar y listar los registros de la tabla Events, que contendrá los campos Id, Name, StartDate, EndDate. La clase debera llamarse MyEventsDataAccess y contener los metodos Create() y List(), donde se realizaran los correspondientes Insert y Select sobre la tabla en la base de datos.

	### Capa de API REST (Servicios Web)
	Crear las operaciones GET /event/create y POST /event/list las cuales invocarán a la clase de persistencia para crear y listar los eventos

	### Capa de Presentación
	Crear la clase EventModel con los campos necesarios para la visualizacion de los datos (el Model)
	Crear la clase EventController (el Controller) con el Get para list y Post  para create
	Crear el html (el View) para las páginas Create.cshtml y List.cshtml

## Redes sociales
- Crear o actualizar cuenta Linkedin con referencias y posts relativos a tu portfolio en Codeacademy, GitHub y agregar aptitudes de las tecnologías aprendidas
