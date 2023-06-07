# Java Junior Developer Roadmap

##  Conceptos básicos Java
- Para refrescar conceptos básicos del desarrollo en Java completar el curso de Codeacademy https://www.codecademy.com/learn/learn-java

## Spring
- Aprender sobre la forma de trabajo de Java EE utilizando el framework Spring en las distintas capas para completar el desarrollo Full-Stack de un proyecto

	### Capa de Persistencia (Acceso a Datos)
	Las clases de esta capa vinculan los objetos Java a estructuras en la base de datos
	- Documentación https://spring.io/guides/gs/relational-data-access/
	- Código de ejemplo https://github.com/spring-guides/gs-relational-data-access.git

	### Capa de API REST (Servicios Web)
	Las clases de esta capa exponen como un servicio web REST las operaciones del servidor (Backend) de la aplicación
	- Documentación crear un servicio https://spring.io/guides/gs/rest-service/	
	- Código de ejemplo https://github.com/spring-guides/gs-rest-service.git

	### Capa de Presentación
	Esta capa accede al servicio REST del Backend y muestra una interfaz de usuario (UI) utilizando el patrón Model-View-Controller (MVC)
	- Documentación acceder a un servicio https://spring.io/guides/gs/consuming-rest/
	- Código de ejemplo https://github.com/spring-guides/gs-consuming-rest.git

	- Documentación Spring MVC Web https://spring.io/guides/gs/serving-web-content/
	- Código de ejemplo https://github.com/spring-guides/gs-serving-web-content.git

## Portfolio
- Crear o acceder una cuenta personal en GitHub 
- Crear un repositorio en GitHub para alojar tu proyecto portfolio (ej. MyEvents). 
- Si terminaste el proyecto MyEvents, también podés ver las distintas guías de desarrollo de Spring para armar más proyectos como portfolio siguiendo los ejemplos https://spring.io/guides
Ej:
https://spring.io/guides/gs/validating-form-input/
https://spring.io/guides/gs/uploading-files/
https://spring.io/guides/gs/spring-boot/

## Primer Proyecto
- Crear el codigo para cada capa del proyecto MyEvents y hacer el push al repositorio
	### Capa de Persistencia
	Crear el acceso a datos para guardar y listar los registros de la tabla Events, que contendrá los campos Id, Name, StartDate, EndDate. La clase debera llamarse MyEventsDataAccess y contener los metodos create() y list(), donde se realizaran los correspondientes Insert y Select sobre la tabla en la base de datos.

	### Capa de API REST (Servicios Web)
	Crear las operaciones GET /event/create y POST /event/list las cuales invocarán a la clase de persistencia para crear y listar los eventos

	### Capa de Presentación
	Crear la clase EventModel con los campos necesarios para la visualizacion de los datos (el Model)
	Crear la clase EventController (el Controller) con el GetMapping para list y PostMapping para create
	Crear el html (el View) para las páginas CreateEvent.html y ListEvents.html

## Redes sociales
- Crear o actualizar cuenta Linkedin con referencias y posts relativos a tu portfolio en Codeacademy, GitHub y agregar aptitudes de las tecnologías aprendidas
