using Microsoft.AspNetCore.Mvc;

using Aeropuerto.EntityModels; 

namespace Aeropuerto.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvioneController : ControllerBase
    {
        
        private readonly AeropuertoContext _context;

        public AvioneController(AeropuertoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var aviones = _context.Aviones.ToList();
            return Ok(aviones);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var avion = _context.Aviones.Find(id);
            if (avion == null)
                return NotFound();
            return Ok(avion);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Avione avion)
        {
            _context.Aviones.Add(avion);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = avion.IdAvion }, avion);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Avione avion)
        {
            if (id != avion.IdAvion)
                return BadRequest();

            _context.Aviones.Update(avion);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var avion = _context.Aviones.Find(id);
            if (avion == null)
                return NotFound();

            _context.Aviones.Remove(avion);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
