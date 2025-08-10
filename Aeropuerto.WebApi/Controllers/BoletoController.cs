using Microsoft.AspNetCore.Mvc;
using Aeropuerto.DataContext.SqlServer1;
using Aeropuerto.EntityModels;

namespace Aeropuerto.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoletoController : ControllerBase
    {
        private readonly AeropuertoDataContext _context;

        public BoletoController(AeropuertoDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var boletos = _context.Boletos.ToList();
            return Ok(boletos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var boleto = _context.Boletos.Find(id);
            if (boleto == null)
                return NotFound();
            return Ok(boleto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Boleto boleto)
        {
            _context.Boletos.Add(boleto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = boleto.IdBoleto }, boleto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Boleto boleto)
        {
            if (id != boleto.IdBoleto)
                return BadRequest();

            _context.Boletos.Update(boleto);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var boleto = _context.Boletos.Find(id);
            if (boleto == null)
                return NotFound();

            _context.Boletos.Remove(boleto);
            _context.SaveChanges();
            return NoContent();
        }
    }
}