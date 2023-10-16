using Microsoft.AspNetCore.Mvc;
using practica2.conte;
using practica2.model;

namespace practica2.Controllers
{
    public class materiaController:ControllerBase
    {
        private readonly appDbcontex _context;

        public materiaController (appDbcontex context)
        {
            _context = context;
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Materia> Get()
        {
            return _context.materias.ToList();
        }
        [HttpPost]
        [Route("materia")]
        public IActionResult CrearMateria([FromBody] Materia matera)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.materias.Add(matera);
                    _context.SaveChanges();
                }
                return Ok(new { mensaje = "Creacion exitosa" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mesaje = error.Message });
            }
        }
        [HttpDelete("ELIMINAR/{Id_Materia}")]
        public IActionResult EliminarMate(int Id_Materia)
        {
            try
            {

                var mate = _context.materias.Find(Id_Materia);

                if (mate == null)
                {
                    return NotFound();
                }

                _context.materias.Remove(mate);
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
