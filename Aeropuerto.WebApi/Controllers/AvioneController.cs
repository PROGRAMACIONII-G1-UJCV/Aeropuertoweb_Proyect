using Microsoft.AspNetCore.Mvc;

using Aeropuerto.EntityModels; 

namespace Aeropuerto.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvioneController(AeropuertoContext context) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
           var aviones = context.Aviones.ToList();
            return Ok(aviones);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var avion = context.Aviones.Find(id);
            if (avion == null)
                return NotFound();
            return Ok(avion);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Avione avion)
        {
            context.Aviones.Add(avion);
            context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = avion.IdAvion }, avion);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Avione avion)
        {
            if (id != avion.IdAvion)
                return BadRequest();

            context.Aviones.Update(avion);
            context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var avion = context.Aviones.Find(id);
            if (avion == null)
                return NotFound();

            context.Aviones.Remove(avion);
            context.SaveChanges();
            return NoContent();
        }
    }
}
