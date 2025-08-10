using Microsoft.AspNetCore.Mvc;
using Aeropuerto.DataContext.SqlServer1;
using Aeropuerto.EntityModels;
using AeropuertoModelos = Aeropuerto.EntityModels;


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

        public IActionResult Create([FromBody] AeropuertoModelos.Aeropuerto aeropuerto)


        {
            _context.Aeropuertos.Add(aeropuerto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = aeropuerto.IdAeropuerto }, aeropuerto);
        }

        [HttpPut("{id}")]


        public IActionResult Update(int id, [FromBody] AeropuertoModelos.Aeropuerto aeropuerto)


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
}
