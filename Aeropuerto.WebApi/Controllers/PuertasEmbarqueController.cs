using Microsoft.AspNetCore.Mvc;
using Aeropuerto.DataContext.SqlServer1;

namespace Aeropuerto.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PuertasEmbarqueController : ControllerBase
    {
        private readonly AeropuertoDataContext _context;

        public PuertasEmbarqueController(AeropuertoDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var puertas = _context.PuertasEmbarques.ToList();
            return Ok(puertas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var puerta = _context.PuertasEmbarques.Find(id);
            if (puerta == null)
                return NotFound();
            return Ok(puerta);
        }

        [HttpPost]
        public IActionResult Create([FromBody] PuertasEmbarque puerta)
        {
            _context.PuertasEmbarques.Add(puerta);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = puerta.IdPuerta }, puerta);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PuertasEmbarque puerta)
        {
            if (id != puerta.IdPuerta)
                return BadRequest();

            _context.PuertasEmbarques.Update(puerta);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var puerta = _context.PuertasEmbarques.Find(id);
            if (puerta == null)
                return NotFound();

            _context.PuertasEmbarques.Remove(puerta);
            _context.SaveChanges();
            return NoContent();
        }
    }
}