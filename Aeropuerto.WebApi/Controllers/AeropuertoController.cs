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

        // GET: api/aeropuerto
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Aeropuerto.EntityModels.Aeropuerto>))]
        public async Task<IEnumerable<Aeropuerto.EntityModels.Aeropuerto>> GetAll()
        {
            return await _context.Aeropuertos.ToListAsync();
        }

        // GET: api/aeropuerto/{id}
        [HttpGet("{id:int}", Name = nameof(GetById))]
        [ProducesResponseType(200, Type = typeof(Aeropuerto.EntityModels.Aeropuerto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            var aeropuerto = await _context.Aeropuertos.FindAsync(id);
            if (aeropuerto == null)
            {
                return NotFound(new { message = $"Aeropuerto con ID {id} no encontrado." });
            }
            return Ok(aeropuerto);
        }

        // POST: api/aeropuerto
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Aeropuerto.EntityModels.Aeropuerto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] Aeropuerto.EntityModels.Aeropuerto aeropuerto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Aeropuertos.Add(aeropuerto);
            await _context.SaveChangesAsync();

            return CreatedAtRoute(
                routeName: nameof(GetById),
                routeValues: new { id = aeropuerto.IdAeropuerto },
                value: aeropuerto);
        }

        // PUT: api/aeropuerto/{id}
        [HttpPut("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] Aeropuerto.EntityModels.Aeropuerto aeropuerto)
        {
            if (id != aeropuerto.IdAeropuerto)
            {
                return BadRequest(new { message = "El ID de la URL no coincide con el ID del objeto." });
            }

            _context.Entry(aeropuerto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Aeropuertos.Any(e => e.IdAeropuerto == id))
                {
                    return NotFound(new { message = $"Aeropuerto con ID {id} no existe." });
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/aeropuerto/{id}
        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var aeropuerto = await _context.Aeropuertos.FindAsync(id);
            if (aeropuerto == null)
            {
                return NotFound(new { message = $"Aeropuerto con ID {id} no encontrado." });
            }

            _context.Aeropuertos.Remove(aeropuerto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
