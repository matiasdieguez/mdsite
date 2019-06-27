
## Add of endpoints in the Api

- Entities with operations exposed as REST endpoints in the Api must have an associated Controller in /ProjectName.Api/Controllers
- The controller class must be named using the name of the entity together with the Controller suffix
- The CRUD operations (Create, Read, Update, Delete) must be marked with the corresponding Http methods (POST, GET, PUT, DELETE)
- Custom operations, eg. get the active languages, they must implement the attribute [Route ("Actives")]
- All operations must implement the [RequireKey] attribute, which requests the corresponding ApiKey to validate it

> /ProjectName.Api/Controllers/LanguageController.cs

```csharp

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectName.Api.Models.Mappings;
using ProjectName.Api.Validations;

namespace ProjectName.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        // GET api/Language
        [RequireKey]
        [HttpGet]
        public IActionResult Get()
        {
            using(var context = new ProjectNameDbContext())
            {
                var list = context.Languages.ToList();
                var dto = list.ToDto();
                return Ok(dto);
            }
        }

        // GET api/Languages/5
        [RequireKey]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using(var context = new ProjectNameDbContext())
            {
                var item = context.Languages.SingleOrDefault(x=>x.Id == id);
                
                if(item == null)
                    return NotFound();

                return Ok(item.ToDto());
            }
        }

        //  POST api/Language
        [RequireKey]
        [HttpPost]
        public IActionResult Post(LanguageDto data)
        {
            var validation = new LanguageValidation().Validate(data);
            if(!validation.IsValid)
                return BadRequest(validation.Errors.ToText());

            using(var context = new ProjectNameDbContext())
            {
                var item = data.FromDto();
                context.Languages.Add(item);
                context.SaveChanges();
                return Ok(item);
            }
        }

        // PUT api/Language
        [RequireKey]
        [HttpPut("{id}")]
        public IActionResult Put(LanguageDto data)
        {
            var validation = new LanguageValidation().Validate(data);
            if(!validation.IsValid)
                return BadRequest(validation.Errors.ToText());

            using(var context = new ProjectNameDbContext())
            {
                var item = context.Languages.SingleOrDefault(x => x.Id == data.Id);
                if(item == null)
                    return NotFound();

                item.FromDto(data);
                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
        }

        // DELETE api/Language/5
        [RequireKey]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using(var context = new ProjectNameDbContext())
            {
                var item = context.Languages.SingleOrDefault(x => x.Id == id);

                if (item != null)
                {
                    context.Entry(item).State = EntityState.Deleted;
                    context.SaveChanges();
                    return Ok(item);
                }
                else
                    return NotFound();
            }
        }

        // GET api/Language/Actives
        [RequireKey]
        [Route("Actives")]
        [HttpGet]
        public IActionResult Actives()
        {
            using(var context = new ProjectNameDbContext())
            {
                var list = context.Languages.Where(x => x.Active == true).ToList();
                var dto = list.ToDto();
                return Ok(dto);
            }
        }
    }
}

```