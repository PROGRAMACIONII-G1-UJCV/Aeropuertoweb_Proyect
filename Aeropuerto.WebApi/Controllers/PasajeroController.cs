using Microsoft.AspNetCore.Mvc;
using Aeropuerto.DataContext.SqlServer1;

namespace Aeropuerto.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasajeroController : ControllerBase
    {
        private readonly AeropuertoDataContext _context;

        public PasajeroController(AeropuertoDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var pasajeros = _context.Pasajeros.ToList();
            return Ok(pasajeros);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var pasajero = _context.Pasajeros.Find(id);
            if (pasajero == null)
                return NotFound();
            return Ok(pasajero);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Pasajero pasajero)
        {
            _context.Pasajeros.Add(pasajero);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = pasajero.IdPasajero }, pasajero);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Pasajero pasajero)
        {
            if (id != pasajero.IdPasajero)
                return BadRequest();

            _context.Pasajeros.Update(pasajero);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pasajero = _context.Pasajeros.Find(id);
            if (pasajero == null)
                return NotFound();

            _context.Pasajeros.Remove(pasajero);
            _context.SaveChanges();
            return NoContent();
        }
    }
}