using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using practica2.conte;
using practica2.model;

namespace practica2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class docenteController : ControllerBase
    {
        private readonly appDbcontex _context;

        public docenteController(appDbcontex context)
        {
            _context = context;
        }
        [Route("")]
        [HttpGet]
        public IEnumerable<docente> Get()
        {
            return _context.docentes.ToList();
        }
        [HttpPost]
        [Route("docente")]
        public IActionResult CrearDocentete([FromBody] docente docente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.docentes.Add(docente);
                    _context.SaveChanges();
                }
                return Ok(new { mensaje = "Creacion exitosa" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mesaje = error.Message });
            }
        }
        [Route("doce")]
        [HttpPut]
        public IActionResult Put([FromBody] docente docente)
        {
            _context.docentes.Update(docente);
            _context.SaveChanges();
            return Ok(docente);
        }

        [HttpDelete("ELIMINAR/{Id_Doce}")]
        public IActionResult EliminarDocente(int Id_Doce)
        {
            try
            {

                var doce = _context.docentes.Find(Id_Doce);

                if (doce == null)
                {
                    return NotFound();
                }

                _context.docentes.Remove(doce);
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

