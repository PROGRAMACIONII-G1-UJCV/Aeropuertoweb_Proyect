using Microsoft.AspNetCore.Mvc;
using Aeropuerto.EntityModels;

namespace Aeropuerto.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly AeropuertoContext _context;

        public EmpleadoController(AeropuertoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var empleados = _context.Empleados.ToList();
            return Ok(empleados);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var empleado = _context.Empleados.Find(id);
            if (empleado == null)
                return NotFound();
            return Ok(empleado);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = empleado.IdEmpleado }, empleado);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Empleado empleado)
        {
            if (id != empleado.IdEmpleado)
                return BadRequest();

            _context.Empleados.Update(empleado);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var empleado = _context.Empleados.Find(id);
            if (empleado == null)
                return NotFound();

            _context.Empleados.Remove(empleado);
            _context.SaveChanges();
            return NoContent();
        }
    }
}