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
    [Route("V1/Pilotos")]
    public class PilotosController : ControllerBase
    {
        private readonly BOEB1590194567 dbContext;

        public PilotosController(BOEB1590194567 dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Piloto>>> Get()
        {
            var cargos = dbContext.Piloto
                    .Include(x => x.Vuelo);


            return await cargos.ToListAsync();
        }



        [HttpGet("{id}")]
        public ActionResult<Piloto> Get(int id)
        {
            var piloto = dbContext.Piloto.Find(id);

            if (piloto == null)
            {
                return NotFound();
            }
            return Ok(piloto);

        }

        [HttpPost]

        public async Task<ActionResult> Post(Piloto piloto)
        {
            dbContext.Piloto.Add(piloto);

            await dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var piloto = await dbContext.Piloto.FindAsync(id);

            if (piloto == null)
            {
                return NotFound();
            }
            dbContext.Remove(piloto);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, Piloto piloto)
        {
            if (id != piloto.IdPiloto)
            {
                return BadRequest();
            }

            dbContext.Entry(piloto).State = EntityState.Modified;

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PilotoExists(id))
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

        private bool PilotoExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
