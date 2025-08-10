using Microsoft.AspNetCore.Mvc;
using Aeropuerto.DataContext.SqlServer1;

namespace Aeropuerto.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AeropuertoController : ControllerBase
    {
        private readonly AeropuertoDataContext _context;

        public AeropuertoController(AeropuertoDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var aeropuertos = _context.Aeropuertos.ToList();
            return Ok(aeropuertos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aeropuerto = _context.Aeropuertos.Find(id);
            if (aeropuerto == null)
                return NotFound();
            return Ok(aeropuerto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] EntityModels.Aeropuerto aeropuerto)
        {
            _context.Aeropuertos.Add(aeropuerto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = aeropuerto.IdAeropuerto }, aeropuerto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] EntityModels.Aeropuerto aeropuerto)
        {
            if (id != aeropuerto.IdAeropuerto)
                return BadRequest();

            _context.Aeropuertos.Update(aeropuerto);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aeropuerto = _context.Aeropuertos.Find(id);
            if (aeropuerto == null)
                return NotFound();

            _context.Aeropuertos.Remove(aeropuerto);
            _context.SaveChanges();
            return NoContent();
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class AvioneController : ControllerBase
    {
        private readonly AeropuertoDataContext _context;

        public AvioneController(AeropuertoDataContext context)
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