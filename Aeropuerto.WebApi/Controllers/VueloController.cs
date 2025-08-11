using Microsoft.AspNetCore.Mvc;
using Aeropuerto.EntityModels;

namespace Aeropuerto.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VueloController : ControllerBase
    {
        private readonly AeropuertoContext _context;

        public VueloController(AeropuertoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var vuelos = _context.Vuelos.ToList();
            return Ok(vuelos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var vuelo = _context.Vuelos.Find(id);
            if (vuelo == null)
                return NotFound();
            return Ok(vuelo);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Vuelo vuelo)
        {
            _context.Vuelos.Add(vuelo);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = vuelo.IdVuelo }, vuelo);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Vuelo vuelo)
        {
            if (id != vuelo.IdVuelo)
                return BadRequest();

            _context.Vuelos.Update(vuelo);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var vuelo = _context.Vuelos.Find(id);
            if (vuelo == null)
                return NotFound();

            _context.Vuelos.Remove(vuelo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}