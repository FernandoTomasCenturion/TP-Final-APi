using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWProvincias_Apellido.Data;
using SWProvincias_Apellido.Models;
using System.Collections.Generic;
using System.Linq;



namespace SWProvincias_Apellido.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciaController : ControllerBase
    { 
           private readonly DBPaisFinalContext context;

            public ProvinciaController(DBPaisFinalContext context)
            {
                this.context = context;
            }

            [HttpGet]
            public ActionResult<IEnumerable<Provincia>> Get()
            {
                return context.Provincias.ToList();
            }



            [HttpGet("{id}")]
            public ActionResult<IEnumerable<Provincia>> Get(int id)
            {

                List<Provincia> provincia = (from l in context.Provincias
                                             where l.IdProvincia == id
                                             select l).ToList();

                return provincia;

            }


            [HttpPost]
            public ActionResult Post(Provincia provincia)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                context.Provincias.Add(provincia);
                context.SaveChanges();
                return Ok();
            }



            [HttpPut("{id}")]
            public ActionResult Put(int id, [FromBody] Provincia provincia)
            {
                if (id != provincia.IdProvincia)
                {
                    return BadRequest();
                }

                context.Entry(provincia).State = EntityState.Modified;
                context.SaveChanges();

                return Ok();

            }

            [HttpDelete("{id}")]
            public ActionResult<Provincia> Delete(int id)
            {
                var provincia = (from a in context.Provincias
                                 where a.IdProvincia == id
                                 select a).SingleOrDefault();
                if (provincia == null)
                {

                    return NotFound();

                }
                context.Provincias.Remove(provincia);
                context.SaveChanges();
                return provincia;

            }
        }
}
