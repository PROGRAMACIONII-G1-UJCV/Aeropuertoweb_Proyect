using Microsoft.AspNetCore.Mvc;
using Aeropuerto.DataContext.SqlServer1;

namespace Aeropuerto.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MantenimientoController : ControllerBase
    {
        private readonly AeropuertoDataContext _context;

        public MantenimientoController(AeropuertoDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var mantenimientos = _context.Mantenimientos.ToList();
            return Ok(mantenimientos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var mantenimiento = _context.Mantenimientos.Find(id);
            if (mantenimiento == null)
                return NotFound();
            return Ok(mantenimiento);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Mantenimiento mantenimiento)
        {
            _context.Mantenimientos.Add(mantenimiento);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = mantenimiento.IdMantenimiento }, mantenimiento);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Mantenimiento mantenimiento)
        {
            if (id != mantenimiento.IdMantenimiento)
                return BadRequest();

            _context.Mantenimientos.Update(mantenimiento);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var mantenimiento = _context.Mantenimientos.Find(id);
            if (mantenimiento == null)
                return NotFound();

            _context.Mantenimientos.Remove(mantenimiento);
            _context.SaveChanges();
            return NoContent();
        }
    }
}