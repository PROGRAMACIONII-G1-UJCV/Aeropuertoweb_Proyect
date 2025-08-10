using Microsoft.AspNetCore.Mvc;
using Aeropuerto.DataContext.SqlServer1;
using Aeropuerto.EntityModels;

namespace Aeropuerto.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipajeController : ControllerBase
    {
        private readonly AeropuertoDataContext _context;

        public EquipajeController(AeropuertoDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var equipajes = _context.Equipajes.ToList();
            return Ok(equipajes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var equipaje = _context.Equipajes.Find(id);
            if (equipaje == null)
                return NotFound();
            return Ok(equipaje);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Equipaje equipaje)
        {
            _context.Equipajes.Add(equipaje);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = equipaje.IdEquipaje }, equipaje);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Equipaje equipaje)
        {
            if (id != equipaje.IdEquipaje)
                return BadRequest();

            _context.Equipajes.Update(equipaje);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var equipaje = _context.Equipajes.Find(id);
            if (equipaje == null)
                return NotFound();

            _context.Equipajes.Remove(equipaje);
            _context.SaveChanges();
            return NoContent();
        }
    }
}