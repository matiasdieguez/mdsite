
## Creating View in App

- In the project /ProjectName.App you must add the .cshtml views according to the MVC convention, creating a folder with the name of the entity inside the Views folder

- The particular javascript codes of the view must be added within @Section Scripts so that they adhere to the _Layout.cshtml after all the js dependent on the liberies used are loaded (eg JQuery)

- The views for the standard operations should be called Index.cshtml, Create.cshtml, Edit.cshtml, Detail.cshtml, Delete.cshtml

- The static files, scripts and css that the views need must be added inside /ProjectName.App/wwwroot/

- The urls to other Actions and Controllers must be generated by means of @ Url.Action ("Controller", "Action", parameters ...), routes must not be hard-coded

- Documentation [https://docs.microsoft.com/en-us/aspnet/core/mvc/views/overview](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/overview)
- Layout [https://docs.microsoft.com/en-us/aspnet/core/mvc/views/working-with-forms](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/working-with-forms)
- Razor (C# in cshtml) [https://docs.microsoft.com/en-us/aspnet/core/mvc/views/razor](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/razor)
- Buttons [https://docs.microsoft.com/en-us/aspnet/core/mvc/views/working-with-forms#the-form-tag-helper](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/working-with-forms#the-form-tag-helper)

> /ProjectName.App/Views/Language/Index.html

```html
@using ProjectName.Localization
<div class="row">
    <h2>@Localizer.Get(Resources.Title)</h2>
</div>

@section Scripts
{

}

```

- Ejemplo form con recursos, post hacia controller/action, validacion y submit button

```html
<form asp-controller="Home" asp-action="Login" method="post">
        <input type="text" class="form-control" id="Username" name="Username" placeholder="@Localizer.Get(Resources.AppLoginUsername)" />
        <span asp-validation-for="Username" class="text-danger"></span>
        <input type="submit" value="Login"/>
</form>

```

- Ejemplo link

```html
<a asp-area="" asp-controller="Home" asp-action="Index">Home</a>
```
