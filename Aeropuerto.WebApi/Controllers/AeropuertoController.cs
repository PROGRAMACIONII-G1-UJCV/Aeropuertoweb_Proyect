using Microsoft.AspNetCore.Mvc;
using Aeropuerto.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AeropuertoController : ControllerBase
    {
        private readonly AeropuertoContext _context;

        public AeropuertoController(AeropuertoContext context)
        {
            _context = context;
        }

        // GET: api/Aeropuerto
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var aeropuertos = await _context.Aeropuertos.ToListAsync();
            return Ok(aeropuertos);
        }

        // GET: api/Aeropuerto/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var aeropuerto = await _context.Aeropuertos.FindAsync(id);
            if (aeropuerto == null)
                return NotFound(new { message = $"Aeropuerto con ID {id} no encontrado." });

            return Ok(aeropuerto);
        }

        // POST: api/Aeropuerto
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Aeropuerto.EntityModels.Aeropuerto aeropuerto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Aeropuertos.Add(aeropuerto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = aeropuerto.IdAeropuerto }, aeropuerto);
        }

        // PUT: api/Aeropuerto/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Aeropuerto.EntityModels.Aeropuerto aeropuerto)
        {
            if (id != aeropuerto.IdAeropuerto)
                return BadRequest(new { message = "El ID de la URL no coincide con el ID del objeto." });

            _context.Entry(aeropuerto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Aeropuertos.Any(e => e.IdAeropuerto == id))
                    return NotFound(new { message = $"Aeropuerto con ID {id} no existe." });

                throw;
            }

            return NoContent();
        }

        // DELETE: api/Aeropuerto/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var aeropuerto = await _context.Aeropuertos.FindAsync(id);
            if (aeropuerto == null)
                return NotFound(new { message = $"Aeropuerto con ID {id} no encontrado." });

            _context.Aeropuertos.Remove(aeropuerto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
