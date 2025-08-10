using Microsoft.AspNetCore.Mvc;
using Aeropuerto.DataContext.SqlServer1;

namespace Aeropuerto.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AerolineaController : ControllerBase
    {
        private readonly AeropuertoDataContext _context;

        public AerolineaController(AeropuertoDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var aerolineas = _context.Aerolineas.ToList();
            return Ok(aerolineas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aerolinea = _context.Aerolineas.Find(id);
            if (aerolinea == null)
                return NotFound();
            return Ok(aerolinea);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Aerolinea aerolinea)
        {
            _context.Aerolineas.Add(aerolinea);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = aerolinea.IdAerolinea }, aerolinea);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Aerolinea aerolinea)
        {
            if (id != aerolinea.IdAerolinea)
                return BadRequest();

            _context.Aerolineas.Update(aerolinea);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aerolinea = _context.Aerolineas.Find(id);
            if (aerolinea == null)
                return NotFound();

            _context.Aerolineas.Remove(aerolinea);
            _context.SaveChanges();
            return NoContent();
        }
    }
}