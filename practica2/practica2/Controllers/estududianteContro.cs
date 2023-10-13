using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using practica2.conte;
using practica2.model;

namespace practica2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class estududianteContro : ControllerBase
    {
        private readonly appDbcontex _context;

        public estududianteContro(appDbcontex context)
        {
            _context = context;
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<estudiante> Get()
        {
            return _context.estudiantes.ToList();
        }
        //Create: Crear estudiantes
        [HttpPost]
        [Route("estu")]
        public IActionResult Crearestudiante([FromBody] estudiante estudiante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.estudiantes.Add(estudiante);
                    _context.SaveChanges();
                }
                return Ok(new { mensaje = "Creacion exitosa" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mesaje = error.Message });
            }
        }
        //Update: Modificar estudiantes
        [Route("/id")]
        [HttpPut]
        public IActionResult Put([FromBody] estudiante estudiante)
        {
            _context.estudiantes.Update(estudiante);
            _context.SaveChanges();
            return Ok(estudiante);
        }
        //Delete: Eliminar estudiantes

        [HttpDelete("ELIMINAR/{Id_estu}")]
        public IActionResult EliminarDocente(int Id_estu)
        {
            try
            {

                var estu = _context.estudiantes.Find(Id_estu);

                if (estu == null)
                {
                    return NotFound();
                }

                _context.estudiantes.Remove(estu);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mesaje = "Eliminado" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mesaje = error.Message });
            }
        }

    }
}
