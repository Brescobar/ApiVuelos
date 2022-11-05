using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenVuelos.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamenVuelos.Entities;


namespace ExamenVuelos.Controllers.V1
{

    [ApiController]
    [Route("V1/Aviones")]
    public class AvionesController : ControllerBase
    {
        private readonly BOEB1590194567 dbContext;

        public AvionesController(BOEB1590194567 dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Avion>>> Get()
        {
            var cargos = dbContext.Avion
                    .Include(x => x.Vuelo);
             

            return await cargos.ToListAsync();
        }



        [HttpGet("{id}")]
        public ActionResult<Avion> Get(int id)
        {
            var avion = dbContext.Avion.Find(id);

            if (avion == null)
            {
                return NotFound();
            }
            return Ok(avion);

        }

        [HttpPost]

        public async Task<ActionResult> Post(Avion avion)
        {
            dbContext.Avion.Add(avion);

            await dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var cargo = await dbContext.Avion.FindAsync(id);

            if (cargo == null)
            {
                return NotFound();
            }
            dbContext.Remove(cargo);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, Avion avion)
        {
            if (id != avion.IdAvion)
            {
                return BadRequest();
            }

            dbContext.Entry(avion).State = EntityState.Modified;

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool AvionExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
